using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Core.Locations
{
    public class Location
    {
        public string Name { get; set; }
        public int PttNum { get; set; }

        public Location(string name, int pttNum)
        {
            Name = name;
            PttNum = pttNum;
        }
    }
}
