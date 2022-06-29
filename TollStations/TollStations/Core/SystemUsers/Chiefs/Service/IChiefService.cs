using System.Collections.Generic;
using TollStations.Core.SystemUsers.Chiefs.Model;

namespace TollStations.Core.SystemUsers.Chiefs.Service
{
    public interface IChiefService
    {
        List<Chief> GetAll();
        Dictionary<int, Chief> GetAllById();
        Dictionary<string, Chief> GetAllByUsername();
        Chief GetById(int id);
        Chief GetByUsername(string username);
        void Save();
        List<Chief> GetAllWithoutStations();
    }
}