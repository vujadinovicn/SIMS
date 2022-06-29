using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.View.ChiefView;
using TollStations.ViewModels.ManagerViewModels;

namespace TollStations.Commands.ManagerCommands
{
    class ManagerDeviceValidationCommand : CommandBase
    {
        ManagerInitialWindowViewModel managerInitialWindowViewModel;
        public ManagerDeviceValidationCommand(ManagerInitialWindowViewModel managerInitialWindowViewModel)
        {
            this.managerInitialWindowViewModel = managerInitialWindowViewModel;
        }
        public override void Execute(object? parameter)
        {
            var window = new DeviceValidationWindow(managerInitialWindowViewModel.GetTollStation());
            window.ShowDialog();
        }
    }
}
