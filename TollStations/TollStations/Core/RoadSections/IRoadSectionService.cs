using System.Collections.Generic;

namespace TollStations.Core.RoadSections
{
    interface IRoadSectionService
    {
        List<RoadSection> GetAll();
    }
}