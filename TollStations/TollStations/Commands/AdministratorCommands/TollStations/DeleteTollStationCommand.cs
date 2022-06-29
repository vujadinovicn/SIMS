using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class DeleteTollStationCommand : CommandBase
    {
        TollStationsTableViewModel _tollStationsTableViewModel;
        IRemovingService _removingService;
        public DeleteTollStationCommand(TollStationsTableViewModel tollStationsTableViewModel, IRemovingService removingService)
        {
            _tollStationsTableViewModel = tollStationsTableViewModel;
            _removingService = removingService;
        }
        public override void Execute(object? parameter)
        {
            var answer = System.Windows.MessageBox.Show("Are you sure you want to delete selected toll station?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (answer == MessageBoxResult.Yes)
            {
                var selectedTollStation = _tollStationsTableViewModel.GetSelectedTollStation();
                if (!_removingService.DeleteTollStation(selectedTollStation))
                    System.Windows.MessageBox.Show("You can not delete toll gate!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                _tollStationsTableViewModel.RefreshGrid();
            }
        }
    }
}
