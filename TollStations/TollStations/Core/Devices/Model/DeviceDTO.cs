using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Devices;

namespace TollStations.Core.Devices.Model
{
    public class DeviceDTO
    {
        public DeviceType Type { get; set; }
        public bool IsValid { get; set; }

        public DeviceDTO(DeviceType type, bool isValid)
        {
            Type = type;
            IsValid = isValid;
        }
    }
}
