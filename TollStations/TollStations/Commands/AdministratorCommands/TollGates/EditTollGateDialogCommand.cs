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
            try {
                var tollGate = _editTollGateDialogViewModel.GetSelectedTollGate();
                var type = _editTollGateDialogViewModel.GetType();
                Cashier cashier = _editTollGateDialogViewModel.GetCashier();
                var number = _editTollGateDialogViewModel.GetNumber();
                TollGateDTO tollGateDTO = new TollGateDTO(number, tollGate.PaymentType, type, tollGate.Devices, cashier, tollGate.TollPayments, tollGate.TollStation);
                _tollGateService.Update(tollGate.Id, tollGateDTO);
                System.Windows.MessageBox.Show("You have succesfully updated new tollStation!", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                
                _editTollGateDialogViewModel.ThisWindow.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
