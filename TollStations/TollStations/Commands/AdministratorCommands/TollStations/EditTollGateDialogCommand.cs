using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollGates;
using TollStations.Core.TollGates.Model;
using TollStations.Core.TollGates.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class EditTollGateDialogCommand : CommandBase
    {
        ITollGateService _tollGateService;
        TollGate _tollGate;
        EditTollGateDialogViewModel _editTollGateDialogViewModel;

        public EditTollGateDialogCommand(EditTollGateDialogViewModel editTollGateDialogViewModel, ITollGateService tollStationService, TollGate tollGate)
        {
            _editTollGateDialogViewModel = editTollGateDialogViewModel;
            _tollGateService = tollStationService;
            _tollGate = tollGate;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var type = _editTollGateDialogViewModel.GetType();
                Cashier cahier = _editTollGateDialogViewModel.GetCashier();
                var number = _editTollGateDialogViewModel.GetNumber();
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
