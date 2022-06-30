using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Devices;
using TollStations.Core.Devices.Model;
using TollStations.Core.Devices.Service;
using TollStations.Core.SystemUsers.Cashiers.Service;
using TollStations.Core.TollGates.Model;
using TollStations.Core.TollGates.Repository;
using TollStations.Core.TollPayments.Model;

namespace TollStations.Core.TollGates.Service
{
    public class TollGateService : ITollGateService
    {
        ITollGateRepository _tollGateRepository;
        ICashierService _cashierService;
        IDeviceService _deviceService;

        public TollGateService(ITollGateRepository tollGateRepository, IDeviceService deviceService, ICashierService cashierService)
        {
            _tollGateRepository = tollGateRepository;
            _deviceService = deviceService;
            _cashierService = cashierService;
        }

        public void Save()
        {
            _tollGateRepository.Save();
        }

        public List<TollGate> GetAll()
        {
            return _tollGateRepository.GetAll();
        }

        public List<TollGate> GetByStation(int id)
        {
            return _tollGateRepository.GetByStation(id);
        }

        public Dictionary<int, TollGate> GetAllByUsername()
        {
            return _tollGateRepository.GetAllByUsername();
        }

        public TollGate GetById(int id)
        {
            return _tollGateRepository.GetById(id);
        }

        public void Add(TollGateDTO tollGateDTO)
        {
            var devices = _deviceService.AddForTollGate();
            TollGate tollGate = new TollGate(tollGateDTO);
            tollGate.Devices = devices;
            _tollGateRepository.Add(tollGate);
            var cashier = tollGate.CurrentCashier;
            cashier.TollGate = tollGate;
            _cashierService.Save();
        }

        public void Update(int id, TollGateDTO tollGateDTO)
        {
            TollGate tollGate = new TollGate(tollGateDTO);
            _tollGateRepository.Update(id, tollGate);
        }

        public void AddTollPayment(int id, TollPayment tollPayment)
        {
            _tollGateRepository.AddTollPayment(id, tollPayment);
        }

        public void AddDevice(int id, DeviceDTO deviceDTO)
        {
            Device device = new Device(deviceDTO);
            _tollGateRepository.AddDevice(id, device);
        }

        public void Delete(int id)
        {
            _tollGateRepository.Delete(id);
        }

        public void DeleteByStation(int stationId)
        {
            List<TollGate> tollGates = GetAll().FindAll(item => item.Id == stationId).ToList();
            foreach (var tollGate in tollGates)
                Delete(tollGate.Id);
        }

        public void DeleteTollPayment(int id, TollPayment tollPayment)
        {
            _tollGateRepository.DeleteTollPayment(id, tollPayment);
        }

        public void DeleteDevice(int id, DeviceDTO deviceDTO)
        {
            Device device = new Device(deviceDTO);
            _tollGateRepository.DeleteDevice(id, device);
        }
    }
}
