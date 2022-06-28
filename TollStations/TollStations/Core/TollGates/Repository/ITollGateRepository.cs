using System.Collections.Generic;
using TollStations.Core.Devices;
using TollStations.Core.TollPayments.Model;

namespace TollStations.Core.TollGates.Repository
{
    public interface ITollGateRepository
    {
        List<TollGate> TollGates { get; set; }
        Dictionary<int, TollGate> TollGatesById { get; set; }

        void Add(TollGate tollGate);
        void AddDevice(int id, Device device);
        void AddTollPayment(int id, TollPayment tollPayment);
        void Delete(int id);
        void DeleteDevice(int id, Device device);
        void DeleteTollPayment(int id, TollPayment tollPayment);
        List<TollGate> GetAll();
        List<TollGate> GetByStation(int id);
        Dictionary<int, TollGate> GetAllByUsername();
        TollGate GetById(int id);
        void LoadFromFile();
        void Save();
        void Update(int id, TollGate byTollGate);
    }
}