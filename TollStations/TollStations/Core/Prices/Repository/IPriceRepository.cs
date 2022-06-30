using System.Collections.Generic;
using TollStations.Core.Prices.Model;

namespace TollStations.Core.Prices.Repositor
{
    public interface IPriceRepository
    {
        Dictionary<int, Price> PriceById { get; set; }
        List<Price> Prices { get; set; }

        void Add(Price price);
        void Delete(int id);
        List<Price> GetAll();
        Dictionary<int, Price> GetAllById();
        Price GetById(int id);
        void LoadFromFile();
        void Save();
        void Update(int id, Price byPrice);
    }
}