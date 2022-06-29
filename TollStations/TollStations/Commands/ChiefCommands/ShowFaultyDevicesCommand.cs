using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.ViewModels.ChiefViewModels;

namespace TollStations.Commands.ChiefCommands
{
    public class ShowFaultyDevicesCommand : CommandBase
    {
        DeviceValidationWindowViewModel _deviceValidationWindowViewModel;

        public ShowFaultyDevicesCommand(DeviceValidationWindowViewModel deviceValidationWindowViewModel)
        {
            _deviceValidationWindowViewModel = deviceValidationWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            _deviceValidationWindowViewModel.RefreshGridForFaulty();
            _deviceValidationWindowViewModel.TollGateComboBoxSelectedIndex = -1;
        }
    }
}
