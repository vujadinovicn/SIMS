using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.Prices;
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards;
using TollStations.Core.TollCards.Model;
using TollStations.View.CashierView;
using TollStations.ViewModels.CashierViewModels;

namespace TollStations.Commands.CashierCommands
{
    public class MakePaymentCommand : CommandBase
    {
        Cashier _loggedCashier;
        private VehicleExitWindowViewModel _vehicleExitWindowViewModel;
        ITollCardService _tollCardService;
        IPriceService _priceService;
        public MakePaymentCommand(VehicleExitWindowViewModel vehicleExitWindowViewModel, Cashier cashier, ITollCardService tollCardService, IPriceService priceService)
        {
            _loggedCashier = cashier;
            _vehicleExitWindowViewModel = vehicleExitWindowViewModel;
            _tollCardService = tollCardService;
            _priceService = priceService;
        }
        public override void Execute(object? parameter)
        {
            int id = _vehicleExitWindowViewModel.GetCardId();
            VehicleType type = _vehicleExitWindowViewModel.GetVehicleType();
            TollCard scannedTollCard = _tollCardService.GetById(id);
            if (scannedTollCard == null)
                MessageBox.Show("Invalid card!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                Price? price = _priceService.GetByAllAttributes(type, scannedTollCard.EntryStation, _loggedCashier.TollStation);
                if (price == null || scannedTollCard.Valid==false)
                    MessageBox.Show("Invalid card!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    var hours = (DateTime.Now - scannedTollCard.Time).TotalHours;
                    if (price.RoadSection.Distance/hours > 6000)
                        MessageBox.Show("Volite pazljivo, neko Vas vozi!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    var window = new PaymentWindow(_loggedCashier, scannedTollCard, price);
                    window.ShowDialog();
                }
            }  

        }
    }
}
