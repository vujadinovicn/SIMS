using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Devices;
using TollStations.Core.TollGates;

namespace TollStations.ViewModels.ModelViewModel
{
    public class DeviceViewModel
    {
        private TollGate _tollGate;
        private Device _device;

        public string TollGateNumber => _tollGate.Number.ToString();
        public TollGateType TollGateType => _tollGate.Type;
        public DeviceType DeviceType => _device.Type;
        public string Correct => _device.IsValid ? "correct" : "faulty";

        public DeviceViewModel(TollGate tollGate, Device device)
        {
            _tollGate = tollGate;
            _device = device;
        }
    }
}
