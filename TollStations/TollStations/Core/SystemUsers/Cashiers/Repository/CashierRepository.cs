using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.Locations.Repository;
using TollStations.Core.SystemUsers.Cashiers.Model;

namespace TollStations.Core.SystemUsers.Cashiers.Repository
{
    public class CashierRepository
    {
        private int _maxId;
        private String _fileName = @"..\..\Data\cashiers.json";
        private ILocationRepository _locationRepository;
        public List<Cashier> Cashiers { get; set; }
        public Dictionary<int, Cashier> CashiersById { get; set; }
        public Dictionary<String, Cashier> CashiersByUsername { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public CashierRepository(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
            this.Cashiers = new List<Cashier>();
            this.CashiersByUsername = new Dictionary<String, Cashier>();
            this.CashiersById = new Dictionary<int, Cashier>();
            this._maxId = 0;
            this.LoadFromFile();
        }

        private Cashier Parse(JToken? cashier)
        {
            var location = _locationRepository.GetById((int)cashier["id"]);
            return new Cashier((int)cashier["id"],
                                      (string)cashier["firstName"],
                                      (string)cashier["lastName"],
                                      (int)cashier["tel"],
                                      (string)cashier["mail"],
                                      (string)cashier["address"],
                                      location,
                                      null,
                                      null);
        }

        public void LoadFromFile()
        {
            var cashiers = JArray.Parse(File.ReadAllText(_fileName));
            foreach (var cashier in cashiers)
            {
                Cashier loadedCashier = Parse(cashier);
                if (loadedCashier.Id > _maxId)
                {
                    _maxId = loadedCashier.Id;
                }
                this.Cashiers.Add(loadedCashier);
                this.CashiersByUsername[loadedCashier.Account.Username] = loadedCashier;
                this.CashiersById[loadedCashier.Id] = loadedCashier;
            }
        }

        private List<dynamic> PrepareForSerialization()
        {
            List<dynamic> reducedCashiers = new List<dynamic>();
            foreach (var cashier in Cashiers)
            {
                reducedCashiers.Add(new
                {
                    id = cashier.Id,
                    firstName = cashier.FirstName,
                    lastName = cashier.LastName,
                    tel = cashier.Tel,
                    mail = cashier.Mail,
                    address = cashier.Address,
                    location = cashier.Location.Id,
                    account = cashier.Account.Id,
                    tollGate = cashier.TollGate.Id
                });
            }
            return reducedCashiers;
        }

        public void Save()
        {
            var allUsers = JsonSerializer.Serialize(this.Cashiers, _options);
            File.WriteAllText(this._fileName, allUsers);
        }

        public List<Cashier> GetAll()
        {
            return this.Cashiers;
        }

        public Dictionary<String, Cashier> GetAllByUsername()
        {
            return CashiersByUsername;
        }

        public Cashier GetByUsername(String username)
        {
            if (this.CashiersByUsername.ContainsKey(username))
                return this.CashiersByUsername[username]; ;
            return null;
        }

        public Dictionary<int, Cashier> GetAllById()
        {
            return CashiersById;
        }

        public Cashier GetById(int id)
        {
            if (this.CashiersById.ContainsKey(id))
                return this.CashiersById[id]; ;
            return null;
        }
    }
}
