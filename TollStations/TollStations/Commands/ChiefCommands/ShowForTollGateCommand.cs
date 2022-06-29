using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollGates;
using TollStations.ViewModels.ChiefViewModels;

namespace TollStations.Commands.ChiefCommands
{
    public class ShowForTollGateCommand : CommandBase
    {
        DeviceValidationWindowViewModel _deviceValidationWindowViewModel;

        public ShowForTollGateCommand(DeviceValidationWindowViewModel deviceValidationWindowViewModel)
        {
            _deviceValidationWindowViewModel = deviceValidationWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            TollGate gate = _deviceValidationWindowViewModel.GetTollGate();
            _deviceValidationWindowViewModel.RefreshGridForGate(gate);
            _deviceValidationWindowViewModel.TollGateComboBoxSelectedIndex = -1;
        }
    }
}
