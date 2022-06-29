using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.View.AdministratorView;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class EditTollStationCommand : CommandBase
    {
        TollStationsTableViewModel _tollStationsTableViewModel;
        public EditTollStationCommand(TollStationsTableViewModel tollStationsTableViewModel)
        {
            _tollStationsTableViewModel = tollStationsTableViewModel;
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<EditTollStationDialog>();
            window.ShowDialog();
            _tollStationsTableViewModel.RefreshGrid();
        }
    }
}
