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
    public class AddTollGateCommand : CommandBase
    {
        TollGatesTableViewModel _tollGatesTableViewModel;
        public AddTollGateCommand(TollGatesTableViewModel tollGatesTableViewModel)
        {
            _tollGatesTableViewModel = tollGatesTableViewModel;
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<AddTollGateDialog>();
            window.ShowDialog();
            _tollGatesTableViewModel.RefreshGrid();
        }
    }
    }
