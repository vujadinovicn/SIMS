using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Locations;
using TollStations.Core.Prices.Model;
using TollStations.Core.Prices.Repositor;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.Prices
{
    public class PriceService : IPriceService
    {
        IPriceRepository _priceRepository;
        public PriceService(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }
        public List<Price> GetAll()
        {
            return _priceRepository.GetAll();
        }

        public Dictionary<int, Price> GetAllById()
        {
            return _priceRepository.GetAllById();
        }

        public Price GetById(int id)
        {
            return _priceRepository.GetById(id);
        }
        public void Add(PriceDTO priceDTO)
        {
            Price price = new Price(priceDTO);
            _priceRepository.Add(price);
        }
        public void Update(int id, PriceDTO priceDTO)
        {
            Price price = new Price(priceDTO);
            _priceRepository.Update(id, price);
        }
        public void Delete(int id)
        {
            _priceRepository.Delete(id);
        }
        public Price GetByAllAttributes(VehicleType vehicleType, TollStation entryStation, TollStation exitStation)
        {
            foreach (Price price in GetAll())
            {
                if (price.RoadSection.EntryStation == entryStation && price.RoadSection.ExitStation == exitStation && price.VehicleType == vehicleType)
                    return price;
            }
            return null;

        }
    }
}
