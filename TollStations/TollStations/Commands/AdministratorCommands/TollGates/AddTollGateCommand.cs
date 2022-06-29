using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;
using TollStations.View.AdministratorView;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.Commands.AdministratorCommands.TollStations
{
    public class AddTollGateCommand : CommandBase
    {
        TollGatesTableViewModel _tollGatesTableViewModel;
        TollStation _tollStation;
        public AddTollGateCommand(TollGatesTableViewModel tollGatesTableViewModel, TollStation tollStation)
        {
            _tollGatesTableViewModel = tollGatesTableViewModel;
            _tollStation = tollStation;
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<AddTollGateDialog>();
            window.SetSelectedTollStation(_tollStation);
            window.ShowDialog();
            _tollGatesTableViewModel.RefreshGrid();
        }
    }
    }
