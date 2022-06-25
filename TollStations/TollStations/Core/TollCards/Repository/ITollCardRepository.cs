using System.Collections.Generic;
using TollStations.Core.TollCards.Model;

namespace TollStations.Core.TollCards.Repository
{
    public interface ITollCardRepository
    {
        List<TollCard> TollCards { get; set; }
        Dictionary<int, TollCard> TollCardsById { get; set; }

        TollCard Add(TollCard card);
        List<TollCard> GetAll();
        Dictionary<int, TollCard> GetAllById();
        TollCard GetById(int id);
        void LoadFromFile();
        void Save();
    }
}