using System.Collections.Generic;

namespace TollStations.Core.Devices.Repository
{
    public interface IDeviceRepository
    {
        Dictionary<int, Device> DeviceById { get; set; }
        List<Device> Devices { get; set; }

        Device Add(Device device);
        void Delete(int id);
        List<Device> GetAll();
        Dictionary<int, Device> GetAllById();
        Device GetById(int id);
        void LoadFromFile();
        void Save();
        void Update(int id, Device byDevice);
    }
}