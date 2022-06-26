using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.RoadSections;

namespace TollStations.Core.Prices.Model
{
    public class Price
    {
        public int Id { get; set; }
        public double PriceInEUR { get; set; }
        public double PriceInRSD { get; set; }
        public VehicleType VehicleType { get; set; }
        public RoadSection RoadSection { get; set; }

        public Price(int id, double priceInEUR, double priceInRSD, VehicleType vehicleType, RoadSection roadSection)
        {
            Id = id;
            PriceInEUR = priceInEUR;
            PriceInRSD = priceInRSD;
            VehicleType = vehicleType;
            RoadSection = roadSection;
        }

        public Price(PriceDTO priceDTO)
        {
            PriceInEUR = priceDTO.PriceInEUR;
            PriceInRSD = priceDTO.PriceInRSD;
            VehicleType = priceDTO.VehicleType;
            RoadSection = priceDTO.RoadSection;
        }
    }

    public enum VehicleType
    {
        Car,
        Motorcycle,
        Van,
        Truck,
        Bus
    }
}
