using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Core.Locations.Model
{
    public class LocationDTO
    {
        public string Name { get; set; }
        public int PttNum { get; set; }

        public LocationDTO(string name, int pttNum)
        {
            Name = name;
            PttNum = pttNum;
        }
    }
}
