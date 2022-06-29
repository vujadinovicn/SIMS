using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards.Model;
using TollStations.Core.TollPayments;
using TollStations.Core.TollPayments.Model;
using TollStations.View;
using TollStations.ViewModels.CashierViewModels;

namespace TollStations.Commands.CashierCommands
{
    public class FinishPaymentCommand : CommandBase
    {
        private PaymentWindowViewModel _paymentWindowViewModel;
        Price _price;
        TollCard _tollCard;
        Cashier _cashier;
        ITollPaymentService _tollPaymentService;
        public FinishPaymentCommand(PaymentWindowViewModel paymentWindowViewModel, ITollPaymentService tollPaymentService, TollCard tollCard, Price price, Cashier cashier)
        {
            _paymentWindowViewModel = paymentWindowViewModel;
            _tollCard = tollCard;
            _price = price;
            _cashier = cashier;
            _tollPaymentService = tollPaymentService;
        }
        public override void Execute(object? parameter)
        {
            int option = _paymentWindowViewModel.GetChosenType();
            double paidAmount = _paymentWindowViewModel.GetPaidAmount();
            double change;
            Currency currency= Currency.RSD;
            double neededAmount = _price.PriceInRSD;
            if (option == 1)
            {
                neededAmount = _price.PriceInEUR;
                currency = Currency.EUR;
                change = (paidAmount - _price.PriceInEUR) * LoginWindow.euroExchangeRate;
            }
            else
                change = paidAmount - _price.PriceInRSD;
            _paymentWindowViewModel.SetChange(change);
            TollPaymentDTO tollPaymentDTO = new TollPaymentDTO(DateTime.Now, currency, neededAmount,_cashier, _tollCard, _cashier.TollGate);
            _tollPaymentService.Add(tollPaymentDTO);

            /*elipsa1.Fill = Brushes.Gray;
            elipsa2.Fill = Brushes.Green;
            */
            
            Random rnd = new Random();
            int milliseconds = rnd.Next(3, 7) * 1000;
            //System.Threading.Thread.Sleep(milliseconds);
            _paymentWindowViewModel.SetChange(milliseconds);
            /*await Task.Delay(milliseconds);

            elipsa1.Fill = Brushes.Red;
            elipsa2.Fill = Brushes.Gray;
            */
        }
        /*public async void Execute(object? parameter)
        {
            int option = _paymentWindowViewModel.GetChosenType();
            double paidAmount = _paymentWindowViewModel.GetPaidAmount();
            double change;
            Currency currency = Currency.RSD;
            if (option == 1)
            {
                currency = Currency.EUR;
                change = (paidAmount - _price.PriceInEUR) * LoginWindow.euroExchangeRate;
            }
            else
                change = paidAmount - _price.PriceInRSD;
            _paymentWindowViewModel.SetChange(change);
            TollPaymentDTO tollPaymentDTO = new TollPaymentDTO(DateTime.Now, currency, paidAmount, _cashier, _tollCard, _cashier.TollGate);
            _tollPaymentService.Add(tollPaymentDTO);

            //elipsa1.Fill = Brushes.Gray;
            //elipsa2.Fill = Brushes.Green;


            Random rnd = new Random();
            int milliseconds = rnd.Next(3, 7) * 1000;
            await Task.Delay(milliseconds);
            _paymentWindowViewModel.SetChange(milliseconds);

            //elipsa1.Fill = Brushes.Red;
            //elipsa2.Fill = Brushes.Gray;

        }*/
    }
}
