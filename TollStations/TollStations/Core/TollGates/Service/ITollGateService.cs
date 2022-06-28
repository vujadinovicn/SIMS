using System.Collections.Generic;
using TollStations.Core.Devices.Model;
using TollStations.Core.TollGates.Model;
using TollStations.Core.TollPayments.Model;

namespace TollStations.Core.TollGates.Service
{
    public interface ITollGateService
    {
        void Add(TollGateDTO tollGateDTO);
        void AddDevice(int id, DeviceDTO deviceDTO);
        void AddTollPayment(int id, TollPayment tollPayment);
        void Delete(int id);
        void DeleteDevice(int id, DeviceDTO deviceDTO);
        void DeleteTollPayment(int id, TollPayment tollPayment);
        List<TollGate> GetAll();
        List<TollGate> GetByStation(int id);
        Dictionary<int, TollGate> GetAllByUsername();
        TollGate GetById(int id);
        void Save();
        void Update(int id, TollGateDTO tollGateDTO);
    }
}