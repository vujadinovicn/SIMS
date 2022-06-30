using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards.Model;
using TollStations.Core.TollGates;

namespace TollStations.Core.TollPayments.Model
{
    public enum Currency
    {
        RSD,
        EUR
    }

    public class TollPayment
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Currency Currency { get; set; }
        public double Amount { get; set; }
        public Cashier Cashier { get; set; }
        public TollCard TollCard { get; set; }
        public TollGate TollGate { get; set; }
        public VehicleType VehicleType { get; set; }

        [JsonConstructor]
        public TollPayment(int id,DateTime time, Currency currency, double amount, Cashier cashier, TollCard tollCard, TollGate tollGate, VehicleType vehicleType)
        {
            Id = id;
            Time = time;
            Currency = currency;
            Amount = amount;
            Cashier = cashier;
            TollCard = tollCard;
            TollGate = tollGate;
            VehicleType = vehicleType;
        }
        public TollPayment(TollPaymentDTO tollPaymentDTO)
        {
            Time = tollPaymentDTO.Time;
            Currency = tollPaymentDTO.Currency;
            Amount = tollPaymentDTO.Amount;
            Cashier = tollPaymentDTO.Cashier;
            TollCard = tollPaymentDTO.TollCard;
            TollGate = tollPaymentDTO.TollGate;
            VehicleType = tollPaymentDTO.VehicleType;
        }

    }
}
