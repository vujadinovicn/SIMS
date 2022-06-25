using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Locations.Model;

namespace TollStations.Core.Locations
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PttNum { get; set; }

        public Location(int id, string name, int pttNum)
        {
            Id = id;
            Name = name;
            PttNum = pttNum;
        }

        public Location(LocationDTO locationDTO)
        {
            Name = locationDTO.Name;
            PttNum = locationDTO.PttNum;
        }
    }
}
