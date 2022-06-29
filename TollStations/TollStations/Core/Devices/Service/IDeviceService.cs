using System.Collections.Generic;
using TollStations.Core.Devices.Model;

namespace TollStations.Core.Devices.Service
{
    public interface IDeviceService
    {
        Device Add(DeviceDTO deviceDTO);
        void Delete(int id);
        List<Device> GetAll();
        void Repair(Device device);
        void ReportFault(Device device);
        void Update(int id, DeviceDTO deviceDTO);
    }
}