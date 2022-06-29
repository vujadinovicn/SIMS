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
    public class EditTollStationDialogCommand : CommandBase
    {
        ITollStationService _tollStationService;
        EditTollStationDialogViewModel _editTollStationDialogViewModel;

        public EditTollStationDialogCommand(EditTollStationDialogViewModel editTollStationDialogViewModel, ITollStationService tollStationService)
        {
            _editTollStationDialogViewModel = editTollStationDialogViewModel;
            _tollStationService = tollStationService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var tollStation = _editTollStationDialogViewModel.GetSelectedTollStation();
                Location location = _editTollStationDialogViewModel.GetLocation();
                Chief chief = _editTollStationDialogViewModel.GetChief();
                TollStationDTO tollStationDTO = new TollStationDTO(chief, tollStation.Gates, location);
                _tollStationService.Update(tollStation.Id, tollStationDTO);
                System.Windows.MessageBox.Show("You have succesfully edited new tollStation!", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                _editTollStationDialogViewModel.ThisWindow.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
