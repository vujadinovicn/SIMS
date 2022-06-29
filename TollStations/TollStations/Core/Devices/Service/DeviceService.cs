using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Devices.Model;
using TollStations.Core.Devices.Repository;

namespace TollStations.Core.Devices.Service
{
    public class DeviceService : IDeviceService
    {
        IDeviceRepository _deviceRepository;
        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public List<Device> GetAll()
        {
            return _deviceRepository.GetAll();
        }

        public Device Add(DeviceDTO deviceDTO)
        {
            Device device = new Device(deviceDTO);
            return _deviceRepository.Add(device);
        }

        public void Update(int id, DeviceDTO deviceDTO)
        {
            Device device = new Device(deviceDTO);
            _deviceRepository.Update(id, device);
        }

        public void Delete(int id)
        {
            _deviceRepository.Delete(id);
        }

        public void Repair(Device device)
        {
            _deviceRepository.Repair(device);
        }

        public void ReportFault(Device device)
        {
            _deviceRepository.ReportFault(device);
        }

        public List<Device> AddForTollGate()
        {
            List<Device> devices = new List<Device>();
            Device device;
            foreach (DeviceType type in Enum.GetValues(typeof(DeviceType)))
            {
                device = Add(new DeviceDTO(type, true));
                devices.Add(device);
            }
            return devices;
        }
    }
}
