using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards.Model;
using TollStations.Core.TollGates;

namespace TollStations.Core.TollPayments.Model
{
    public class TollPaymentDTO
    {
        public DateTime Time { get; set; }
        public Currency Currency { get; set; }
        public double Amount { get; set; }
        public Cashier Cashier { get; set; }
        public TollCard TollCard { get; set; }
        public TollGate TollGate { get; set; }
        public VehicleType VehicleType { get; set; }

        public TollPaymentDTO(DateTime time, Currency currency, double amount, Cashier cashier, TollCard tollCard, TollGate tollGate, VehicleType vehicleType)
        {
            Time = time;
            Currency = currency;
            Amount = amount;
            Cashier = cashier;
            TollCard = tollCard;
            TollGate = tollGate;
            VehicleType = vehicleType;
        }
    }
}
