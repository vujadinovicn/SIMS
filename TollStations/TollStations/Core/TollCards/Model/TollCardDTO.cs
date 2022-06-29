using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.TollCards.Model
{
    public class TollCardDTO
    {
        public DateTime Time { get; set; }
        public string Plate { get; set; }
        public TollStation EntryStation { get; set; }
        public bool Valid { get; set; }
        public TollCardDTO(DateTime time, string plate, TollStation tollStation, bool valid)
        {
            Time = time;
            Plate = plate;
            EntryStation = tollStation;
            Valid = valid;
        }
    }
}
