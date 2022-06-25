using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStation.Core.Locations;
using TollStation.Core.SystemUsers.Cashiers;
using TollStation.Core.SystemUsers.Chiefs;
using TollStation.Core.TollGates;

namespace TollStation.Core.TollStations
{
    public class TollStation
    {
        public int Id { get; set; }
        public Chief Chief { get; set; }
        public List<TollGate> Gates { get; set; }
        public List<Cashier> Cashiers { get; set; }
        public Location Location { get; set; }

        public TollStation(int id, Chief chief, List<TollGate> gates, List<Cashier> cashiers, Location location)
        {
            Id = id;
            Chief = chief;
            Gates = gates;
            Cashiers = cashiers;
            Location = location;
        }
    }
}
