using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollGates;
using TollStations.Core.TollPayments.Model;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.Reports
{
    public class MostVisitedStationsReportService : IMostVisitedStationsReportService
    {
        ITollStationService tollStationService;
        Dictionary<TollStation, int> paymentsByStation;

        public MostVisitedStationsReportService(ITollStationService tollStationService)
        {
            this.tollStationService = tollStationService;
            InitializePaymentsByStation();
        }

        public Dictionary<TollStation, int> GetAll(DateTime start, DateTime end)
        {
            InitializePaymentsByStation();
            int b = 0;
            foreach (TollStation station in tollStationService.GetAll())
            {
                foreach (TollGate gate in station.Gates)
                {
                    b += addNumOfPayments(gate.TollPayments, start, end);
                }
                paymentsByStation[station] = b;
                b = 0;
            }
            SortDict();
            return paymentsByStation;
        }

        private void SortDict()
        {
            Dictionary<TollStation, int> sortedDict = new Dictionary<TollStation, int>();
            int b = 1;
            foreach (var item in paymentsByStation.OrderByDescending(x => x.Value))
            {
                sortedDict[item.Key] = item.Value;
                b += 1;
                if (b > 5) break;
            }
            paymentsByStation = sortedDict;
        }

        private int addNumOfPayments(List<TollPayment> payments, DateTime start, DateTime end)
        {
            int b = 0;
            foreach (TollPayment payment in payments)
            {
                if (payment.Time > start && payment.Time < end) b += 1;
            }
            return b;
        }

        private void InitializePaymentsByStation()
        {
            if (paymentsByStation is null) paymentsByStation = new Dictionary<TollStation, int>();
            paymentsByStation.Clear();
            foreach (TollStation station in tollStationService.GetAll())
            {
                paymentsByStation[station] = 0;
            }
        }


    }
}
