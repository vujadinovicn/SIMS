using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class DeleteTollGateCommand : CommandBase
    {
        TollGatesTableViewModel _tollGatesTableViewModel;
        IRemovingService _removingService;
        public DeleteTollGateCommand(TollGatesTableViewModel tollGatesTableViewModel, IRemovingService removingService)
        {
            _tollGatesTableViewModel = tollGatesTableViewModel;
            _removingService = removingService;
        }
        public override void Execute(object? parameter)
        {
            var answer = System.Windows.MessageBox.Show("Are you sure you want to delete selected toll gate?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (answer == MessageBoxResult.Yes)
            {
                var selectedTollGate = _tollGatesTableViewModel.GetSelectedTollGate();
                if (_removingService.ContainsPayments(selectedTollGate))
                    System.Windows.MessageBox.Show("You can not delete toll gate!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                    _removingService.DeleteTollGate(selectedTollGate);
                _tollGatesTableViewModel.RefreshGrid();
            }
        }
    }
}

