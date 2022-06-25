using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards.Model;

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
        internal TollCard TollCard { get; set; }


        public TollPayment(int id, DateTime time, Currency currency, double amount, Cashier cashier, TollCard tollCard)
        {
            Id = id;
            Time = time;
            Currency = currency;
            Amount = amount;
            Cashier = cashier;
            TollCard = tollCard;
        }
    }
}
