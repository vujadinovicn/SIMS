using System.Collections.Generic;
using TollStations.Core.Prices.Model;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.Prices
{
    public interface IPriceService
    {
        void Add(PriceDTO priceDTO);
        void Delete(int id);
        List<Price> GetAll();
        Dictionary<int, Price> GetAllById();
        Price GetByAllAttributes(VehicleType vehicleType, TollStation entryStation, TollStation exitStation);
        Price GetById(int id);
        void Update(int id, PriceDTO priceDTO);
    }
}