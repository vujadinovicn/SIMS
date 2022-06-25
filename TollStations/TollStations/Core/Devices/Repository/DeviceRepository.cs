using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStation.Core.Devices;

namespace TollStations.Core.Devices.Repository
{
    public class DeviceRepository
    {
        private int _maxId;
        private String _fileName = @"..\..\Data\devices.json";
        public List<Device> Devices { get; set; }
        public Dictionary<int, Device> DevicesById { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };


    }
}
