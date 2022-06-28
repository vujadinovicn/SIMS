using System;
using System.Collections.Generic;
using TollStations.Core.Locations;
using TollStations.Core.TollGates;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.TollCards.Model;

namespace TollStations.Core.TollStations.Model
{
    public class TollStation
    {
        public int Id { get; set; }
        public Chief Chief { get; set; }
        public List<TollGate> Gates { get; set; }
        public Location Location { get; set; }

        public TollStation(int id, Chief chief, List<TollGate> gates, Location location)
        {
            Id = id;
            Chief = chief;
            Gates = gates;
            Location = location;
        }

        public override string ToString()
        {
            return "ID: " + Id + "  |  Location: " + Location;
        }
    }
}
