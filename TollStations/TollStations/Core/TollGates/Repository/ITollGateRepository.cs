using System.Collections.Generic;
using TollStations.Core.Devices;
using TollStations.Core.TollPayments.Model;

namespace TollStations.Core.TollGates.Repository
{
    public interface ITollGateRepository
    {
        void Add(TollGate tollGate);
        void AddDevice(int id, Device device);
        void AddTollPayment(int id, TollPayment tollPayment);
        void Delete(TollGate tollGate);
        void DeleteDevice(int id, Device device);
        void DeleteTollPayment(int id, TollPayment tollPayment);
        List<TollGate> GetAll();
        Dictionary<int, TollGate> GetAllByUsername();
        TollGate GetById(int id);
        void LoadFromFile();
        void Save();
        void Update(TollGate byTollGate);
    }
}