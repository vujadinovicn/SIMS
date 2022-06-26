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
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.SystemUsers.Users.Repository;
using TollStations.Core.TollStations.Repository;

namespace TollStations.Core.SystemUsers.Chiefs.Repository
{
    public class ChiefRepository : IChiefRepository
    {
        private int _maxId;
        private String _fileName = @"..\..\..\Data\chiefs.json";
        private IAccountRepository _accountRepository;
        private ILocationRepository _locationRepository;
        private ITollStationRepository _tollStationRepository;
        public List<Chief> Chiefs { get; set; }
        public Dictionary<int, Chief> ChiefsById { get; set; }
        public Dictionary<String, Chief> ChiefsByUsername { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public ChiefRepository(IAccountRepository accountRepository, ITollStationRepository tollStationRepository, ILocationRepository locationRepository)
        {
            _accountRepository = accountRepository;
            _locationRepository = locationRepository;
            _tollStationRepository = tollStationRepository;
            this.Chiefs = new List<Chief>();
            this.ChiefsByUsername = new Dictionary<String, Chief>();
            this.ChiefsById = new Dictionary<int, Chief>();
            this._maxId = 0;
            this.LoadFromFile();
        }

        private Chief Parse(JToken? chief)
        {
            var location = _locationRepository.GetById((int)chief["id"]);
            var account = _accountRepository.GetById((int)chief["account"]);
            var tollStation = _tollStationRepository.GetById((int)chief["tollStation"]);
            var loadedChief = new Chief((int)chief["id"],
                                      (string)chief["firstName"],
                                      (string)chief["lastName"],
                                      (int)chief["tel"],
                                      (string)chief["mail"],
                                      (string)chief["address"],
                                      location,
                                      account,
                                      tollStation);
            if (tollStation != null)
                tollStation.Chief = loadedChief;
            account.User = loadedChief;
            return loadedChief;
        }

        public void LoadFromFile()
        {
            var chiefs = JArray.Parse(File.ReadAllText(_fileName));
            foreach (var chief in chiefs)
            {
                Chief loadedChief = Parse(chief);
                if (loadedChief.Id > _maxId)
                {
                    _maxId = loadedChief.Id;
                }
                this.Chiefs.Add(loadedChief);
                this.ChiefsByUsername[loadedChief.Account.Username] = loadedChief;
                this.ChiefsById[loadedChief.Id] = loadedChief;
            }
        }

        private List<dynamic> PrepareForSerialization()
        {
            List<dynamic> reducedChiefs = new List<dynamic>();
            foreach (var chief in Chiefs)
            {
                reducedChiefs.Add(new
                {
                    id = chief.Id,
                    firstName = chief.FirstName,
                    lastName = chief.LastName,
                    tel = chief.Tel,
                    mail = chief.Mail,
                    address = chief.Address,
                    location = chief.Location.Id,
                    account = chief.Account.Id,
                    tollStation = chief.TollStation.Id
                });
            }
            return reducedChiefs;
        }

        public void Save()
        {
            var allUsers = JsonSerializer.Serialize(this.Chiefs, _options);
            File.WriteAllText(this._fileName, allUsers);
        }

        public List<Chief> GetAll()
        {
            return this.Chiefs;
        }

        public Dictionary<String, Chief> GetAllByUsername()
        {
            return ChiefsByUsername;
        }

        public Chief GetByUsername(String username)
        {
            if (this.ChiefsByUsername.ContainsKey(username))
                return this.ChiefsByUsername[username]; ;
            return null;
        }

        public Dictionary<int, Chief> GetAllById()
        {
            return ChiefsById;
        }

        public Chief GetById(int id)
        {
            if (this.ChiefsById.ContainsKey(id))
                return this.ChiefsById[id]; ;
            return null;
        }
    }
}
