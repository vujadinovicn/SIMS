using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Repository;

namespace TollStations.Core.TollStations
{
    public class TollStationService : ITollStationService
    {
        ITollStationRepository tollStationRepository;

        public TollStationService(ITollStationRepository tollStationRepository)
        {
            this.tollStationRepository = tollStationRepository;
        }

        public List<TollStation> GetAll()
        {
            return tollStationRepository.GetAll();
        }
    }
}
