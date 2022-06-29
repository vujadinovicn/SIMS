using System.Collections.Generic;

namespace TollStations.Core.Locations.Service
{
    public interface ILocationService
    {
        List<Location> GetAll();
        Dictionary<int, Location> GetAllById();
        Location GetById(int id);
        void Save();
    }
}