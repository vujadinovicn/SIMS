using System.Collections.Generic;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.TollStations.Repository
{
    public interface ITollStationRepository
    {
        void Add(TollStation tollStation);
        void AddTollGate(int id, TollGate tollGate);
        void Delete(int id);
        void DeleteTollGate(int id, TollGate tollGate);
        List<TollStation> GetAll();
        Dictionary<int, TollStation> GetAllById();
        TollStation GetById(int id);
        void LoadFromFile();
        void Save();
        void Update(int id, TollStation byTollStation);
    }
}