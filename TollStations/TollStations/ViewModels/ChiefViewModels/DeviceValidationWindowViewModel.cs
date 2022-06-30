using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.ChiefCommands;
using TollStations.Core.Devices;
using TollStations.Core.Devices.Service;
using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;
using TollStations.ViewModels.ModelViewModel;

namespace TollStations.ViewModels.ChiefViewModels
{
    public class DeviceValidationWindowViewModel : ViewModelBase
    {
        IDeviceService _deviceService;
        TollStation TollStation { get; set; }
        public ICommand ShowForTollGateCommand { get; }
        public ICommand RepairCommand { get; }
        public ICommand ReportFaultCommand { get; }
        public ICommand ShowFaultyDevicesCommand { get; }
        public ICommand ShowForAllGatesCommand { get; }
        public DeviceValidationWindowViewModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;
            ShowForTollGateCommand = new ShowForTollGateCommand(this);
            RepairCommand = new RepairCommand(this, deviceService);
            ReportFaultCommand = new ReportFaultCommand(this, deviceService);
            ShowFaultyDevicesCommand = new ShowFaultyDevicesCommand(this);
            ShowForAllGatesCommand = new ShowForAllGatesCommand(this);

            CanShow = false;
            CanRepair = false;
            CanReportFault = false;


        }
        public void SetTollStation(TollStation tollStation)
        {
            TollStation = tollStation;
            LoadTollGateComboBox();

            Devices = new();
            _devicesVM = new();
            RefreshGrid();
        }
        bool _canShow;
        public bool CanShow {
            get
            {
                return _canShow;
            }
            set
            {
                _canShow = value;
                OnPropertyChanged(nameof(CanShow));
            }
        }

        bool _canRepair;
        public bool CanRepair {
            get
            {
                return _canRepair;
            }
            set
            {
                _canRepair = value;
                OnPropertyChanged(nameof(CanRepair));
            }
        }
        bool _canReportFault;
        public bool CanReportFault {
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

        private ObservableCollection<TollGate> _tollGateComboBoxItems;

        public ObservableCollection<TollGate> TollGateComboBoxItems
        {
            get
            {
                return _tollGateComboBoxItems;
            }
            set
            {
                _tollGateComboBoxItems = value;
                OnPropertyChanged(nameof(TollGateComboBoxItems));
            }
        }
        private int _tollGateCombBoxSelectedIndex;

        public int TollGateComboBoxSelectedIndex
        {
            get
            {
                return _tollGateCombBoxSelectedIndex;
            }
            set
            {
                _tollGateCombBoxSelectedIndex = value;
                if (_tollGateCombBoxSelectedIndex != -1)
                {
                    CanShow = true;
                } else
                {
                    CanShow=false;
                }
                OnPropertyChanged(nameof(TollGateComboBoxSelectedIndex));
            }
        }


        public TollGate GetTollGate()
        {
            return TollGateComboBoxItems[TollGateComboBoxSelectedIndex];
        }

        private void LoadTollGateComboBox()
        {
            TollGateComboBoxItems = new();
            foreach (TollGate tollGate in TollStation.Gates)
            {
                TollGateComboBoxItems.Add(tollGate);
            }
            TollGateComboBoxSelectedIndex = -1;
        }

        //
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
                        CanRepair = false;
                    }
                    else
                    {
                        CanRepair = true;
                        CanReportFault = false;
                    }
                } else
                {
                    CanRepair = false;
                    CanReportFault=false;
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
            foreach (TollGate gate in TollStation.Gates)
            {
                foreach(Device device in gate.Devices)
                {
                    Devices.Add(device);
                    _devicesVM.Add(new DeviceViewModel(gate, device));
                }
            }
        }

        public Device GetSelectedDevice()
        {
            return Devices[_selectedDeviceIndex];
        }

        public void RefreshGridForGate(TollGate gate)
        {
            _devicesVM.Clear();
            Devices.Clear();
            
            foreach (Device device in gate.Devices)
            {
                Devices.Add(device);
                _devicesVM.Add(new DeviceViewModel(gate, device));
            }          
        }

        public void RefreshGridForFaulty()
        {
            _devicesVM.Clear();
            Devices.Clear();
            foreach (TollGate gate in TollStation.Gates)
            {
                foreach (Device device in gate.Devices)
                {
                    if (!device.IsValid)
                    {
                        Devices.Add(device);
                        _devicesVM.Add(new DeviceViewModel(gate, device));
                    }                 
                }
            }
        }
    }
}
