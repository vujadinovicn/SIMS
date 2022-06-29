using System.Collections.Generic;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.TollStations
{
    public interface ITollStationService
    {
        List<TollStation> GetAll();
    }
}