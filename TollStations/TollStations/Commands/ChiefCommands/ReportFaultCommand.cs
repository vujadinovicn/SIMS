using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.Devices;
using TollStations.Core.Devices.Service;
using TollStations.ViewModels.ChiefViewModels;

namespace TollStations.Commands.ChiefCommands
{
    public class ReportFaultCommand : CommandBase
    {
        DeviceValidationWindowViewModel _deviceValidationWindowViewModel;
        IDeviceService _deviceService;
        public ReportFaultCommand(DeviceValidationWindowViewModel deviceValidationWindowViewModel, IDeviceService deviceService)
        {
            _deviceValidationWindowViewModel = deviceValidationWindowViewModel;
            _deviceService = deviceService;

        }

        public override void Execute(object? parameter)
        {
            Device selectedDevice = _deviceValidationWindowViewModel.GetSelectedDevice();
            _deviceService.ReportFault(selectedDevice);
            _deviceValidationWindowViewModel.CanReportFault = false;
            _deviceValidationWindowViewModel.SelectedDeviceIndex = -1;
            _deviceValidationWindowViewModel.Refresh();
            MessageBox.Show("Device error reported successfully", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
