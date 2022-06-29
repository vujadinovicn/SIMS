using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.View.AdministratorView.TollStations;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class TollStationsCashiersTableCommand : CommandBase
    {
        TollStationsTableViewModel _tollStationsTableViewModel;
        public TollStationsCashiersTableCommand(TollStationsTableViewModel tollStationsTableViewModel)
        {
            _tollStationsTableViewModel = tollStationsTableViewModel;
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<TollStationsCashiersTable>();
            window.SetTollStation(_tollStationsTableViewModel.GetSelectedTollStation());
            window.ShowDialog();
        }
    }
}
