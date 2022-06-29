using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.RoadSections.Model;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.RoadSections
{
    public class RoadSection
    {
        public int Id { get; set; }
        public TollStation EntryStation { get; set; }
        public TollStation ExitStation { get; set; }
        public double Distance { get; set; }

        public RoadSection(int id, TollStation entryStation, TollStation exitStation, double distance)
        {
            Id = id;
            EntryStation = entryStation;
            ExitStation = exitStation;
            Distance = distance;
        }

        public RoadSection(RoadSectionDTO roadSectionDTO)
        {
            EntryStation = roadSectionDTO.EntryStation;
            ExitStation = roadSectionDTO.ExitStation;
            Distance = roadSectionDTO.Distance;
        }
    }
}
