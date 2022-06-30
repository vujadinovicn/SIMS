using System.Collections.Generic;
using TollStations.Core.Locations;
using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.TollStations.Service
{
    public interface ITollStationService
    {
        void Add(TollStationDTO tollStationDTO);
        void AddTollGate(int id, TollGate tollGate);
        void Delete(int id);
        void DeleteTollGate(int id, TollGate tollGate);
        List<TollStation> GetAll();
        Dictionary<int, TollStation> GetAllById();
        TollStation GetById(int id);
        void Save();
        void Update(int id, TollStationDTO tollStationDTO);
        List<Location> GetLocationsWithoutStations();
    }
}