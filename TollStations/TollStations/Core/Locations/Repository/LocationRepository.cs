using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TollStations.Core.Locations.Repository
{
    public class LocationRepository
    {
        private String _fileName = @"..\..\..\Data\locations.json";

        private int _maxId;
        public List<Location> Locations { get; set; }
        public Dictionary<int, Location> LocationById { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public LocationRepository()
        {
            this.Locations = new List<Location>();
            this.LocationById = new Dictionary<int, Location>();
            this._maxId = 0;
            this.LoadFromFile();
        }

        public void LoadFromFile()
        {
            var locations = JsonSerializer.Deserialize<List<Location>>(File.ReadAllText(_fileName), _options);
            foreach (Location location in locations)
            {
                if (location.Id > _maxId)
                {
                    _maxId = location.Id;
                }
                this.Locations.Add(location);
                this.LocationById.Add(location.Id, location);
            }
        }

        public void Save()
        {
            var allLocations = JsonSerializer.Serialize(this.Locations, _options);
            File.WriteAllText(this._fileName, allLocations);
        }

        public List<Location> GetAll()
        {
            return this.Locations;
        }

        public Dictionary<int, Location> GetAllById()
        {
            return this.LocationById;
        }

        public Location GetById(int id)
        {
            if (LocationById.ContainsKey(id))
                return LocationById[id];
            return null;
        }

        public Location Add(Location location)
        {
            this._maxId++;
            int id = this._maxId;
            location.Id = id;

            this.Locations.Add(location);
            this.LocationById.Add(location.Id, location);
            Save();
            return location;
        }

        public void Update(int id, Location byLocation)
        {
            Location location = GetById(id);
            location.Name = byLocation.Name;
            location.PttNum = byLocation.PttNum;
            Save();
        }

        public void Delete(int id)
        {
            Location location = GetById(id);
            this.Locations.Remove(location);
            this.LocationById.Remove(id);
            Save();
        }
    }
}
