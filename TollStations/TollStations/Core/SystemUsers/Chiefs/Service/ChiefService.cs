using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.SystemUsers.Chiefs.Repository;

namespace TollStations.Core.SystemUsers.Chiefs.Service
{
    public class ChiefService : IChiefService
    {
        IChiefRepository _chiefRepository;

        public ChiefService(IChiefRepository chiefRepository)
        {
            _chiefRepository = chiefRepository;
        }
        public void Save()
        {
            _chiefRepository.Save();
        }

        public List<Chief> GetAll()
        {
            return _chiefRepository.GetAll();
        }

        public Dictionary<String, Chief> GetAllByUsername()
        {
            return _chiefRepository.GetAllByUsername();
        }

        public Chief GetByUsername(String username)
        {
            return _chiefRepository.GetByUsername(username);
        }

        public Dictionary<int, Chief> GetAllById()
        {
            return _chiefRepository.GetAllById();
        }

        public Chief GetById(int id)
        {
            return _chiefRepository.GetById(id);
        }

        public List<Chief> GetAllWithoutStations()
        {
            return _chiefRepository.GetAllWithoutStations();
        }
    }
}
