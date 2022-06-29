using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.Devices;

namespace TollStations.Core.Devices.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private String _fileName = @"..\..\..\Data\devices.json";

        private int _maxId;
        public List<Device> Devices { get; set; }
        public Dictionary<int, Device> DeviceById { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public DeviceRepository()
        {
            this.Devices = new List<Device>();
            this.DeviceById = new Dictionary<int, Device>();
            this._maxId = 0;
            this.LoadFromFile();
        }

        public void LoadFromFile()
        {
            var devices = JsonSerializer.Deserialize<List<Device>>(File.ReadAllText(_fileName), _options);
            foreach (Device device in devices)
            {
                if (device.Id > _maxId)
                {
                    _maxId = device.Id;
                }
                this.Devices.Add(device);
                this.DeviceById.Add(device.Id, device);
            }
        }

        public void Save()
        {
            var allLocations = JsonSerializer.Serialize(this.Devices, _options);
            File.WriteAllText(this._fileName, allLocations);
        }

        public List<Device> GetAll()
        {
            return this.Devices;
        }

        public Dictionary<int, Device> GetAllById()
        {
            return this.DeviceById;
        }

        public Device GetById(int id)
        {
            if (DeviceById.ContainsKey(id))
                return DeviceById[id];
            return null;
        }

        public Device Add(Device device)
        {
            this._maxId++;
            int id = this._maxId;
            device.Id = id;

            this.Devices.Add(device);
            this.DeviceById.Add(device.Id, device);
            Save();
            return device;
        }

        public void Update(int id, Device byDevice)
        {
            Device device = GetById(id);
            device.Id = byDevice.Id;
            device.Type = byDevice.Type;
            device.IsValid = byDevice.IsValid;
            Save();
        }

        public void Delete(int id)
        {
            Device device = GetById(id);
            this.Devices.Remove(device);
            this.DeviceById.Remove(id);
            Save();
        }

        public void Repair(Device device)
        {
            device.IsValid = true;
            Save();
        }

        public void ReportFault(Device device)
        {
            device.IsValid = false;
            Save();
        }
    }
}
