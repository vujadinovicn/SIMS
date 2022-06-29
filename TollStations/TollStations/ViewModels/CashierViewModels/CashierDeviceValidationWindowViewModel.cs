using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.CashierCommands;
using TollStations.Commands.ChiefCommands;
using TollStations.Core.Devices;
using TollStations.Core.Devices.Service;
using TollStations.Core.TollGates;
using TollStations.ViewModels.ModelViewModel;

namespace TollStations.ViewModels.CashierViewModels
{
    public class CashierDeviceValidationWindowViewModel : ViewModelBase
    {
        IDeviceService _deviceService;
        TollGate TollGate { get; set; }

        public ICommand ReportFaultCashierCommand { get; }

        public CashierDeviceValidationWindowViewModel(TollGate tollGate, IDeviceService deviceService)
        {
            ReportFaultCashierCommand = new ReportFaultCashierCommand(this, deviceService);

            CanReportFault = false;
            TollGate = tollGate;

            Devices = new();
            _devicesVM = new();
            RefreshGrid();
            _deviceService = deviceService;

        }
    
        bool _canReportFault;
        public bool CanReportFault
        {
            get
            {
                return _canReportFault;
            }
            set
            {
                _canReportFault = value;
                OnPropertyChanged(nameof(CanReportFault));
            }
        }


        public List<Device> Devices;

        private int _selectedDeviceIndex;

        public int SelectedDeviceIndex
        {
            get
            {
                return _selectedDeviceIndex;
            }
            set
            {
                _selectedDeviceIndex = value;
                if (value is not -1)
                {
                    if (GetSelectedDevice().IsValid)
                    {
                        CanReportFault = true;                       
                    }
                    else
                    {
                        CanReportFault = false;
                    }
                }
                else
                {
                    CanReportFault = false;
                }
                OnPropertyChanged(nameof(SelectedDeviceIndex));

            }
        }

        private ObservableCollection<DeviceViewModel> _devicesVM;

        public ObservableCollection<DeviceViewModel> DevicesVM
        {
            get
            {
                return _devicesVM;
            }
            set
            {
                _devicesVM = value;
                OnPropertyChanged(nameof(DevicesVM));
            }
        }
        public void Refresh()
        {
            List<DeviceViewModel> refreshDevices = _devicesVM.ToList();
            _devicesVM.Clear();
            foreach (DeviceViewModel dvm in refreshDevices)
            {
                _devicesVM.Add(dvm);
            }
        }

        public void RefreshGrid()
        {
            _devicesVM.Clear();
            Devices.Clear();

            foreach (Device device in TollGate.Devices)
            {
                Devices.Add(device);
                _devicesVM.Add(new DeviceViewModel(TollGate, device));
            }
        }

        public Device GetSelectedDevice()
        {
            return Devices[_selectedDeviceIndex];
        }

    }
}
