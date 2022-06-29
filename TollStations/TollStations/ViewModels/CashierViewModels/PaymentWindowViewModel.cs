using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.CashierCommands;
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards.Model;
using TollStations.Core.TollPayments;

namespace TollStations.ViewModels.CashierViewModels
{
    public class PaymentWindowViewModel : ViewModelBase
    {
        ITollPaymentService _tollPaymentService;
        public PaymentWindowViewModel(ITollPaymentService tollPaymentService)
        {
            _tollPaymentService = tollPaymentService;
        }
        public void SetIncomingParameters(Cashier cashier, TollCard tollCard, Price price)
        {
            ReturnChangeCommand = new FinishPaymentCommand(this,_tollPaymentService ,tollCard, price, cashier);
        }
        public ICommand ReturnChangeCommand { get; set; }

        private object _choice = "0";

        public object Choice
        {
            get
            {
                return _choice;
            }
            set
            {
                _choice = value;
                OnPropertyChanged(nameof(Choice));
            }
        }

        public int GetChosenType()
        {
            return Convert.ToInt32(Choice as string);
        }

        private string paid;
        public string Paid
        {
            get
            {
                return paid;
            }
            set
            {
                paid = value;
                OnPropertyChanged(nameof(Paid));
            }
        }

        public double GetPaidAmount()
        {
            return double.Parse(Paid);
        }

        private double change;
        public double Change
        {
            get
            {
                return change;
            }
            set
            {
                change = value;
                OnPropertyChanged(nameof(Change));
            }
        }

        public void SetChange(double val)
        {
            Change = val;
        }

    }
}
