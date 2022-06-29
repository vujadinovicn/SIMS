using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class DeleteTollStationCommand : CommandBase
    {
        TollStationsTableViewModel _tollStationsTableViewModel;
        ITollStationService _tollStationService;
        public DeleteTollStationCommand(TollStationsTableViewModel tollStationsTableViewModel, ITollStationService tollStationService)
        {
            _tollStationsTableViewModel = tollStationsTableViewModel;
            _tollStationService = tollStationService;
        }
        public override void Execute(object? parameter)
        {
            var answer = System.Windows.MessageBox.Show("Are you sure you want to delete selected examination?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (answer == MessageBoxResult.Yes)
            {
                var selectedTollStation = _tollStationsTableViewModel.GetSelectedTollStation();
                _tollStationService.Delete(selectedTollStation.Id);
                _tollStationsTableViewModel.RefreshGrid();
            }
        }
    }
}
