using System.Collections.Generic;

namespace TollStations.Core.Locations.Repository
{
    public interface ILocationRepository
    {
        Dictionary<int, Location> LocationById { get; set; }
        List<Location> Locations { get; set; }

        Location Add(Location location);
        void Delete(int id);
        List<Location> GetAll();
        Dictionary<int, Location> GetAllById();
        Location GetById(int id);
        void LoadFromFile();
        void Save();
        void Update(int id, Location byLocation);
    }
}