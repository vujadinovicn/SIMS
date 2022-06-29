using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.SystemUsers.Cashiers.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class AddTollStationsCashierDialogCommand : CommandBase
    {
        ICashierService _cashierService;
        TollStationsCashiersTableViewModel _tollStationsCashiersTableViewModel;

        public AddTollStationsCashierDialogCommand(TollStationsCashiersTableViewModel tollStationsCashiersTableViewModel, ICashierService cashierService)
        {
            _tollStationsCashiersTableViewModel = tollStationsCashiersTableViewModel;
            _cashierService = cashierService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var cashier = _tollStationsCashiersTableViewModel.GetCashier();
                _cashierService.AddStation(cashier, _tollStationsCashiersTableViewModel.GetTollStation());
                System.Windows.MessageBox.Show("You have added a cashier! ", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                _tollStationsCashiersTableViewModel.CashierComboBoxItems.Remove(cashier);
                if (_tollStationsCashiersTableViewModel.CashierComboBoxItems.Count == 0)
                {
                    System.Windows.MessageBox.Show("You have added all free cashiers!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    //_consumedEquipmentDialogViewModel.ThisWindow.Close();
                }
                _tollStationsCashiersTableViewModel.RefreshGrid();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
