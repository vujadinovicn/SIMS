using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollCards.Model;
using TollStations.Core.TollCards.Repository;

namespace TollStations.Core.TollCards
{
    public class TollCardService : ITollCardService
    {
        ITollCardRepository _tollCardRepository;
        public TollCardService(ITollCardRepository tollCardRepository)
        {
            _tollCardRepository = tollCardRepository;
        }

        public List<TollCard> GetAll()
        {
            return _tollCardRepository.GetAll();
        }
        public Dictionary<int, TollCard> GetAllById()
        {
            return _tollCardRepository.GetAllById();
        }
        public TollCard GetById(int id)
        {
            return _tollCardRepository.GetById(id);
        }
        public TollCard Add(TollCardDTO tollCardDTO)
        {
            TollCard tollCard = new TollCard(tollCardDTO);
            return _tollCardRepository.Add(tollCard);
        }
    }
}
