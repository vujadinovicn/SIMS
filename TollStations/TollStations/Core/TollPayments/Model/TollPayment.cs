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

    class TollPayment
    {
        DateTime time;
        Currency currency;
        double amount;
        Cashier cashier;
        TollCard tollCard;

        public TollPayment(DateTime time, Currency currency, double amount, Cashier cashier, TollCard tollCard)
        {
            this.time = time;
            this.currency = currency;
            this.amount = amount;
            this.cashier = cashier;
            this.tollCard = tollCard;
        }

        public DateTime Time { get => time; set => time = value; }
        public Currency Currency { get => currency; set => currency = value; }
        public double Amount { get => amount; set => amount = value; }
        public Cashier Cashier { get => cashier; set => cashier = value; }
        internal TollCard TollCard { get => tollCard; set => tollCard = value; }
    }
}
