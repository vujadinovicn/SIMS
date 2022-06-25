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
        TrafficLightColor color;

        public TrafficLight(int id, bool isValid, TrafficLightColor color) : base(id, DeviceType.TrafficLight, isValid)
        {
            this.color = color;
        }

        public TrafficLightColor Color { get => color; set => color = value; }
    }
}
