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
using TollStations.View;

namespace TollStations.Core.Reports
{
    public class EarningsByVehicleTypeReportService : IEarningsByVehicleTypeReportService
    {
        Dictionary<VehicleType, double> earningsByType;

        public EarningsByVehicleTypeReportService()
        {
            InitializeEarningsByType();
        }

        public Dictionary<VehicleType, double> GetAll(TollStation station, DateTime start, DateTime end)
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
                if (payment.Currency==Currency.EUR)
                    earningsByType[payment.VehicleType] += payment.Amount*LoginWindow.euroExchangeRate;
                else
                    earningsByType[payment.VehicleType] += payment.Amount; 
                    
            }
        }

        private void InitializeEarningsByType()
        {
            if (earningsByType is null) earningsByType = new Dictionary<VehicleType, double>();
            earningsByType.Clear();
            foreach (VehicleType type in Enum.GetValues(typeof(VehicleType)))
            {
                earningsByType[type] = 0;
            }
        }
    }
}
