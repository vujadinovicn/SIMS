using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.RoadSections;

namespace TollStations.Core.Prices.Model
{
    public class PriceDTO
    {
        public double PriceInEUR { get; set; }
        public double PriceInRSD { get; set; }
        public VehicleType VehicleType { get; set; }
        public RoadSection RoadSection { get; set; }

        public PriceDTO(double priceInEUR, double priceInRSD, VehicleType vehicleType, RoadSection roadSection)
        {
            PriceInEUR = priceInEUR;
            PriceInRSD = priceInRSD;
            VehicleType = vehicleType;
            RoadSection = roadSection;
        }
    }
}
