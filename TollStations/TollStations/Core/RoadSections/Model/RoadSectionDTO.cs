using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.RoadSections.Model
{
    public class RoadSectionDTO
    {
        public TollStation EntryStation { get; set; }
        public TollStation ExitStation { get; set; }

        public RoadSectionDTO(TollStation entryStation, TollStation exitStation)
        {
            EntryStation = entryStation;
            ExitStation = exitStation;
        }
    }
}
