using System.Collections.Generic;
using TollStations.Core.SystemUsers.Chiefs.Model;

namespace TollStations.Core.SystemUsers.Chiefs.Repository
{
    public interface IChiefRepository
    {
        List<Chief> Chiefs { get; set; }
        Dictionary<int, Chief> ChiefsById { get; set; }
        Dictionary<string, Chief> ChiefsByUsername { get; set; }

        List<Chief> GetAll();
        Dictionary<int, Chief> GetAllById();
        Dictionary<string, Chief> GetAllByUsername();
        Chief GetById(int id);
        Chief GetByUsername(string username);
        void LoadFromFile();
        void Save();
        List<Chief> GetAllWithoutStations();
    }
}