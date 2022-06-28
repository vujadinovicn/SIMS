using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Prices.Model;
using TollStations.Core.TollGates;
using TollStations.Core.TollPayments.Model;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.Reports
{
    public class EarningsByVehicleTypeReportService : IEarningsByVehicleTypeReportService
    {
        ITollStationService tollStationService;
        Dictionary<VehicleType, int> earningsByType;

        public EarningsByVehicleTypeReportService(ITollStationService tollStationService)
        {
            this.tollStationService = tollStationService;
            InitializeEarningsByType();
        }

        public Dictionary<VehicleType, int> GetAll(TollStation station, DateTime start, DateTime end)
        {
            InitializeEarningsByType();

            foreach (TollGate gate in station.Gates)
            {
                foreach (TollPayment payment in gate.TollPayments)
                {
                    AddPayment(payment, start, end);
                }
            }

            return earningsByType;
        }

        private void AddPayment(TollPayment payment, DateTime start, DateTime end)
        {
            if (payment.Time > start && payment.Time < end)
            {
                earningsByType[payment.VehicleType] += 1;
            }
        }

        private void InitializeEarningsByType()
        {
            if (earningsByType is null) earningsByType = new Dictionary<VehicleType, int>();
            earningsByType.Clear();
            foreach (VehicleType type in Enum.GetValues(typeof(VehicleType)))
            {
                earningsByType[type] = 0;
            }
        }
    }
}
