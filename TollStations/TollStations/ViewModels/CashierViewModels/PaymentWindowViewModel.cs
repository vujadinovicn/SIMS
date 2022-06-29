using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands;
using TollStations.Commands.CashierCommands;
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards.Model;
using TollStations.Core.TollPayments;
using TollStations.Core.TollPayments.Model;
using TollStations.View;

namespace TollStations.ViewModels.CashierViewModels
{
    public class PaymentWindowViewModel : ViewModelBase
    {
        ITollPaymentService _tollPaymentService;
        TollCard _tollCard;
        Price _price;
        Cashier _loggedCashier;
        public IAsyncCommand Submit { get; private set; }
        public PaymentWindowViewModel(ITollPaymentService tollPaymentService)
        {
            _tollPaymentService = tollPaymentService;
        }
        public void SetIncomingParameters(Cashier cashier, TollCard tollCard, Price price)
        {
            //ReturnChangeCommand = new FinishPaymentCommand(this,_tollPaymentService ,tollCard, price, cashier);
            _tollCard = tollCard;
            _price = price;
            _loggedCashier = cashier;
            ReturnChangeCommand = new AsyncCommand(ExecuteSubmitAsync, CanExecuteSubmit);
        }
        public ICommand ReturnChangeCommand { get; set; }

        private async Task ExecuteSubmitAsync()
        {
            try
            {
                IsBusy = true;
                /*var coffeeService = new CoffeeService();
                await coffeeService.PrepareCoffeeAsync();
                */
                int option = GetChosenType();
                double paidAmount = GetPaidAmount();
                double change;
                Currency currency = Currency.RSD;
                double neededAmount = _price.PriceInRSD;
                if (option == 1)
                {
                    neededAmount = _price.PriceInEUR;
                    currency = Currency.EUR;
                    change = (paidAmount - _price.PriceInEUR) * LoginWindow.euroExchangeRate;
                }
                else
                    change = paidAmount - _price.PriceInRSD;
                SetChange(change);
                TollPaymentDTO tollPaymentDTO = new TollPaymentDTO(DateTime.Now, currency, neededAmount, _loggedCashier, _tollCard, _loggedCashier.TollGate);
                _tollPaymentService.Add(tollPaymentDTO);

                /*elipsa1.Fill = Brushes.Gray;
                elipsa2.Fill = Brushes.Green;
                */

                Random rnd = new Random();
                int milliseconds = rnd.Next(3, 7) * 1000;
                //System.Threading.Thread.Sleep(milliseconds);
                SetChange(milliseconds);
                await Task.Delay(milliseconds);

                /*elipsa1.Fill = Brushes.Red;
                elipsa2.Fill = Brushes.Gray;
                */
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanExecuteSubmit()
        {
            return !IsBusy;
        }
        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        
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
