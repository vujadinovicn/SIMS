using System.Collections.Generic;
using TollStations.Core.TollCards.Model;

namespace TollStations.Core.TollCards
{
    public interface ITollCardService
    {
        TollCard Add(TollCardDTO tollCardDTO);
        List<TollCard> GetAll();
        Dictionary<int, TollCard> GetAllById();
        TollCard GetById(int id);
    }
}