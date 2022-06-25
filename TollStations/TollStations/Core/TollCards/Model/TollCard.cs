using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.TollCards.Model
{
    public class TollCard
    {
        public int Id { get; set; }
        public DateTime Time { get ; set ; }
        public string Plate { get ; set ; }
        public TollStation EntryStation { get; set; }

        public TollCard(int id, DateTime time, string plate, TollStation tollStation)
        {
            Id = id;
            Time = time;
            Plate = plate;
            EntryStation = tollStation;
        }

        public TollCard(int id, DateTime time, string plate)
        {
            Id = Id;
            Time = time;
            Plate = plate;
        }
    }
}
