using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Core.TollCards.Model
{
    class TollCard
    {
        DateTime time;
        string plate;

        public TollCard(DateTime time, string plate)
        {
            this.time = time;
            this.plate = plate;
        }

        public DateTime Time { get => time; set => time = value; }
        public string Plate { get => plate; set => plate = value; }
    }
}
