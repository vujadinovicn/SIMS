using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.Prices.Model;
using TollStations.Core.RoadSections;
using TollStations.Core.RoadSections.Repository;

namespace TollStations.Core.Prices.Repositor
{
    public class PriceRepository : IPriceRepository
    {
        private String _fileName = @"..\..\..\Data\prices.json";

        private IRoadSectionRepository _roadSectionRepository;

        private int _maxId;
        public List<Price> Prices { get; set; }
        public Dictionary<int, Price> PriceById { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public PriceRepository(IRoadSectionRepository roadSectionRepository)
        {
            _roadSectionRepository = roadSectionRepository;
            this.Prices = new List<Price>();
            this.PriceById = new Dictionary<int, Price>();
            this._maxId = 0;
            this.LoadFromFile();
        }

        private Price Parse(JToken? price)
        {
            Dictionary<int, RoadSection> roadSectionById = _roadSectionRepository.GetAllById();

            int id = (int)price["id"];
            double priceInEUR = (double)price["priceInEUR"];
            double priceInRSD = (double)price["priceInRSD"];

            VehicleType vehicleType;
            Enum.TryParse<VehicleType>((string)price["vehicleType"], out vehicleType);

            int roadSectionId = (int)price["roadSection"];
            RoadSection roadSection = roadSectionById[roadSectionId];

            return new Price(id, priceInEUR, priceInRSD, vehicleType, roadSection);
        }

        public void LoadFromFile()
        {
            var prices = JArray.Parse(File.ReadAllText(_fileName));

            foreach (var price in prices)
            {
                Price loadedPrice = Parse(price);
                int id = loadedPrice.Id;

                if (id > _maxId)
                {
                    _maxId = id;
                }

                this.Prices.Add(loadedPrice);
                this.PriceById[id] = loadedPrice;
            }
        }

        private List<dynamic> PrepareForSerialization()
        {
            List<dynamic> reducedPrices = new List<dynamic>();
            foreach (var price in this.Prices)
            {
                reducedPrices.Add(new
                {
                    id = price.Id,
                    priceInEUR = price.PriceInEUR,
                    priceInRSD = price.PriceInRSD,
                    vehicleType = price.VehicleType,
                    roadSection = price.RoadSection.Id,
                });
            }
            return reducedPrices;
        }

        public void Save()
        {
            var allPrices = JsonSerializer.Serialize(PrepareForSerialization(), _options);
            File.WriteAllText(this._fileName, allPrices);
        }

        public List<Price> GetAll()
        {
            return this.Prices;
        }

        public Dictionary<int, Price> GetAllById()
        {
            return this.PriceById;
        }

        public Price GetById(int id)
        {
            if (PriceById.ContainsKey(id))
                return PriceById[id];
            return null;
        }

        public void Add(Price price)
        {
            this._maxId++;
            int id = this._maxId;
            price.Id = id;

            this.Prices.Add(price);
            this.PriceById.Add(price.Id, price);
            Save();
        }

        public void Update(int id, Price byPrice)
        {
            Price price = GetById(id);
            price.PriceInEUR = byPrice.PriceInEUR;
            price.PriceInRSD = byPrice.PriceInRSD;
            price.VehicleType = byPrice.VehicleType;
            price.RoadSection = byPrice.RoadSection;
            Save();
        }

        public void Delete(int id)
        {
            Price price = GetById(id);
            this.Prices.Remove(price);
            this.PriceById.Remove(id);
            Save();
        }

    }
}
