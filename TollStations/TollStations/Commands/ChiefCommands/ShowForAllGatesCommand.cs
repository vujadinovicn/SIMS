using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.ViewModels.ChiefViewModels;

namespace TollStations.Commands.ChiefCommands
{
    public class ShowForAllGatesCommand : CommandBase
    {
        DeviceValidationWindowViewModel _deviceValidationWindowViewModel;

        public ShowForAllGatesCommand(DeviceValidationWindowViewModel deviceValidationWindowViewModel)
        {
            _deviceValidationWindowViewModel = deviceValidationWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            _deviceValidationWindowViewModel.RefreshGrid();
            _deviceValidationWindowViewModel.TollGateComboBoxSelectedIndex = -1;
        }
    }
}
