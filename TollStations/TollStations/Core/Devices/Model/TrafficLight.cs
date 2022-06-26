using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Devices;

namespace TollStations.Core.Devices.Model
{
    public enum TrafficLightColor
    {
        RED,
        GREEN
    }

    public class TrafficLight : Device
    {
        public TrafficLightColor Color { get; set; }
        public TrafficLight(int id, bool isValid, TrafficLightColor color) : base(id, DeviceType.TRAFFIC_LIGHT, isValid)
        {
            this.Color = color;
        }
    }
}
