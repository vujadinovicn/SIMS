using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollGates.Model;
using TollStations.Core.TollGates.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class AddTollGateDialogCommand : CommandBase
    {
        ITollGateService _tollGateService;
        AddTollGateDialogViewModel _addTollGateDialogViewModel;

        public AddTollGateDialogCommand(AddTollGateDialogViewModel addTollGateDialogViewModel, ITollGateService tollStationService)
        {
            _addTollGateDialogViewModel = addTollGateDialogViewModel;
            _tollGateService = tollStationService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var type = _addTollGateDialogViewModel.GetType();
                Cashier cahier = _addTollGateDialogViewModel.GetCashier();
                var number = _addTollGateDialogViewModel.GetNumber();
                //TollGateDTO tollGateDTO = new TollGateDTO();
                //_tollGateService.Add(tollGateDTO);
                System.Windows.MessageBox.Show("You have succesfully added new tollStation!", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
