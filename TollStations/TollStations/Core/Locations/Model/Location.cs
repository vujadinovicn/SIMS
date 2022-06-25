using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStation.Core.Locations
{
    public class Location
    {
        string name;
        int pttNum;

        public Location(string name, int pttNum)
        {
            this.name = name;
            this.pttNum = pttNum;
        }

        public string Name { get => name; set => name = value; }
        public int PttNum { get => pttNum; set => pttNum = value; }
    }
}
