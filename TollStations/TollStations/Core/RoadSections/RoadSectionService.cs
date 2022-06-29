using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.RoadSections.Repository;

namespace TollStations.Core.RoadSections
{
    class RoadSectionService : IRoadSectionService
    {
        IRoadSectionRepository roadSectionRepository;

        public RoadSectionService(IRoadSectionRepository roadSectionRepository)
        {
            this.roadSectionRepository = roadSectionRepository;
        }

        public List<RoadSection> GetAll()
        {
            return roadSectionRepository.GetAll();
        }
    }
}
