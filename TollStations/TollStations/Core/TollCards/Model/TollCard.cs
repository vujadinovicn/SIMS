﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.TollCards.Model
{
    public class TollCard
    {
        public DateTime Time { get ; set ; }
        public string Plate { get ; set ; }
        public TollStation EntryStation { get; set; }

        public TollCard(DateTime time, string plate, TollStation tollStation)
        {
            this.Time = time;
            this.Plate = plate;
            this.EntryStation = tollStation;
        }
    }
}