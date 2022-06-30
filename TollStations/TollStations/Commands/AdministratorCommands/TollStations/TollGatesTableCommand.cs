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
    public class TollGatesTableCommand : CommandBase
    {
        TollStationsTableViewModel _tollStationsTableViewModel;
        public TollGatesTableCommand(TollStationsTableViewModel tollStationsTableViewModel)
        {
            _tollStationsTableViewModel = tollStationsTableViewModel;
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<TollGatesTable>();
            window.SetTollStation(_tollStationsTableViewModel.GetSelectedTollStation());
            window.ShowDialog();
        }
    }
}
