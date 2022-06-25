using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.Locations;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.TollStations.Repository
{
    public class TollStationRepository : ITollStationRepository
    {
        private String _fileName = @"..\..\..\Data\tollStations.json";
        ICashierRepository _cashierRepository;
        ILocationRepository _locationRepository;
        public List<TollStation> TollStations { get; set; }
        public Dictionary<int, TollStation> TollStationsById { get; set; }
        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };
        public TollStationRepository(ICashierRepository cashierRepository, ILocationRepository locationRepository)
        {
            _cashierRepository = cashierRepository;
            _locationRepository = locationRepository;
            TollStations = new List<TollStation>();
            TollStationsById = new Dictionary<int, TollStation>();
            this.LoadFromFile();
        }
        private List<Cashier> JToken2Cashiers(JToken tokens)
        {
            Dictionary<int, Cashier> cashiersById = _cashierRepository.GetAllById();
            List<Cashier> items = new List<Cashier>();
            foreach (int token in tokens)
                items.Add(cashiersById[token]);
            return items;
        }

        private TollStation Parse(JToken? tollStation)
        {
            Dictionary<int, Location> locationsById = _locationRepository.GetAllById();
            return new TollStation((int)tollStation["id"],
                                   null, null,
                                   JToken2Cashiers(tollStation["cashiers"]),
                                   locationsById[(int)tollStation["location"]]);
        }

        public void LoadFromFile()
        {
            var tollStations = JArray.Parse(File.ReadAllText(_fileName));
            foreach (var tollStation in tollStations)
            {
                TollStation loadedTollStation = Parse(tollStation);
                this.TollStations.Add(loadedTollStation);
                this.TollStationsById[loadedTollStation.Id] = loadedTollStation;
            }
        }

        private List<dynamic> PrepareForSerialization()
        {
            List<dynamic> reducedTollStations = new List<dynamic>();
            foreach (var tollStation in this.TollStations)
            {
                List<int> gatesId = new List<int>();
                List<int> cashiersId = new List<int>();
                foreach (var i in tollStation.Gates)
                    gatesId.Add(i.Id);
                foreach (var i in tollStation.Cashiers)
                    cashiersId.Add(i.Id);
                reducedTollStations.Add(new
                {
                    id = tollStation.Id,
                    cashiers = tollStation.Cashiers,
                    location = tollStation.Location
                });
            }
            return reducedTollStations;
        }

        public void Save()
        {
            var allMedicalRecords = JsonSerializer.Serialize(PrepareForSerialization(), _options);
            File.WriteAllText(this._fileName, allMedicalRecords);
        }

        public List<TollStation> GetAll()
        {
            return this.TollStations;
        }

        public Dictionary<int, TollStation> GetAllById()
        {
            return this.TollStationsById;
        }

        public TollStation GetById(int id)
        {
            if (TollStationsById.ContainsKey(id))
                return TollStationsById[id];
            return null;
        }

        public void Add(TollStation tollStation)
        {
            this.TollStations.Add(tollStation);
            this.TollStationsById[tollStation.Id] = tollStation;
            Save();
        }

        public void Update(TollStation byTollStation)
        {
            TollStation tollStation = GetById(byTollStation.Id);
            tollStation.Location = byTollStation.Location;
            tollStation.Chief = byTollStation.Chief;
            tollStation.Cashiers = byTollStation.Cashiers;
            tollStation.Gates = byTollStation.Gates;
            Save();
        }

        public void AddTollGate(int id, TollGate tollGate)
        {
            TollStation tollStation = GetById(id);
            tollStation.Gates.Add(tollGate);
            Save();
        }

        public void AddCashier(int id, Cashier cashier)
        {
            TollStation tollStation = GetById(id);
            tollStation.Cashiers.Add(cashier);
            Save();
        }

        public void Delete(TollStation tollStation)
        {
            this.TollStations.Remove(tollStation);
            this.TollStationsById.Remove(tollStation.Id);
            Save();
        }

        public void DeleteTollGate(int id, TollGate tollGate)
        {
            TollStation tollStation = GetById(id);
            tollStation.Gates.Remove(tollGate);
            Save();
        }

        public void DeleteCashier(int id, Cashier cashier)
        {
            TollStation tollStation = GetById(id);
            tollStation.Cashiers.Remove(cashier);
            Save();
        }
    }
}
