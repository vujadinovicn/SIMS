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
    public class AddTollStationCommand : CommandBase
    {
        TollStationsTableViewModel _tollStationsTableViewModel;
        public AddTollStationCommand(TollStationsTableViewModel tollStationsTableViewModel)
        {
            _tollStationsTableViewModel = tollStationsTableViewModel;
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<AddTollStationDialog>();
            window.ShowDialog();
            _tollStationsTableViewModel.RefreshGrid();
        }
    }
}
