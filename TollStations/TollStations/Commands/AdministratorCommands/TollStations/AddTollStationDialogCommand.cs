using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.Locations;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.SystemUsers.Chiefs.Service;
using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class AddTollStationDialogCommand : CommandBase
    {
        ITollStationService _tollStationService;
        AddTollStationDialogViewModel _addTollStationDialogViewModel;

        public AddTollStationDialogCommand(AddTollStationDialogViewModel addTollStationDialogViewModel, ITollStationService tollStationService)
        {
            _addTollStationDialogViewModel = addTollStationDialogViewModel;
            _tollStationService = tollStationService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                Location location = _addTollStationDialogViewModel.GetLocation();
                Chief chief = _addTollStationDialogViewModel.GetChief();
                TollStationDTO tollStationDTO = new TollStationDTO(chief, new List<TollGate>(), location);
                _tollStationService.Add(tollStationDTO);
                System.Windows.MessageBox.Show("You have succesfully added new tollStation!", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
