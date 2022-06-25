using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.RoadSections.Repository
{
    public class RoadSectionRepository
    {
        private String _fileName = @"..\..\..\Data\roadSections.json";

        private ITollStationRepository _tollStationRepository;

        private int _maxId;
        public List<RoadSection> RoadSections { get; set; }
        public Dictionary<int, RoadSection> RoadSectionById { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public RoadSectionRepository(ITollStationRepository tollStationRepository)
        {
            _tollStationRepository = tollStationRepository;
            this.RoadSections = new List<RoadSection>();
            this.RoadSectionById = new Dictionary<int, RoadSection>();
            this._maxId = 0;
            this.LoadFromFile();
        }

        private RoadSection Parse(JToken? roadSection)
        {
            Dictionary<int, TollStation> tollStationById = _tollStationRepository.GetAllById();

            int id = (int)roadSection["id"];
            int entryStationId = (int)roadSection["entryStation"];
            TollStation entryStation = tollStationById[entryStationId];
            int exitStationId = (int)roadSection["exitStation"];
            TollStation exitStation = tollStationById[exitStationId];

            return new RoadSection(id, entryStation, exitStation);
        }

        public void LoadFromFile()
        {
            var roadSections = JArray.Parse(File.ReadAllText(_fileName));

            foreach (var roadSection in roadSections)
            {
                RoadSection loadedRoadSection = Parse(roadSection);
                int id = loadedRoadSection.Id;

                if (id > _maxId)
                {
                    _maxId = id;
                }

                this.RoadSections.Add(loadedRoadSection);
                this.RoadSectionById[id] = loadedRoadSection;
            }
        }

        private List<dynamic> PrepareForSerialization()
        {
            List<dynamic> reducedRoadSections = new List<dynamic>();
            foreach (var roadSection in this.RoadSections)
            {
                reducedRoadSections.Add(new
                {
                    id = roadSection.Id,
                    entryStation = roadSection.EntryStation.Id,
                    exitStation = roadSection.ExitStation.Id,
                });
            }
            return reducedRoadSections;
        }

        public void Save()
        {
            var allRoadSections = JsonSerializer.Serialize(PrepareForSerialization(), _options);
            File.WriteAllText(this._fileName, allRoadSections);
        }

        public List<RoadSection> GetAll()
        {
            return this.RoadSections;
        }

        public Dictionary<int, RoadSection> GetAllById()
        {
            return this.RoadSectionById;
        }

        public RoadSection GetById(int id)
        {
            if (RoadSectionById.ContainsKey(id))
                return RoadSectionById[id];
            return null;
        }

        public void Add(RoadSection roadSection)
        {
            this._maxId++;
            int id = this._maxId;
            roadSection.Id = id;

            this.RoadSections.Add(roadSection);
            this.RoadSectionById.Add(roadSection.Id, roadSection);
            Save();
        }

        public void Update(int id, RoadSection byRoadSection)
        {
            RoadSection roadSection = GetById(id);
            roadSection.EntryStation = byRoadSection.EntryStation;
            roadSection.ExitStation = byRoadSection.ExitStation;
            Save();
        }

        public void Delete(int id)
        {
            RoadSection roadSection = GetById(id);
            this.RoadSections.Remove(roadSection);
            this.RoadSectionById.Remove(id);
            Save();
        }
    }
}
