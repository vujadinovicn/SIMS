using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Core.Devices.Model
{
    public class TrafficLightDTO
    {
        public DeviceType Type { get; set; }
        public bool IsValid { get; set; }
        public TrafficLightColor Color { get; set; }

        public TrafficLightDTO(bool isValid, TrafficLightColor color)
        {
            Type = DeviceType.TRAFFIC_LIGHT;
            Color = color;
            IsValid = isValid;
        }
    }
}
