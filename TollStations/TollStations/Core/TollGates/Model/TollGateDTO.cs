using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStation.Core.Devices;
using TollStation.Core.SystemUsers.Cashiers;
using TollStation.Core.TollGates;

namespace TollStations.Core.TollGates.Model
{
    public class TollGateDTO
    {
        public int Number { get; set; }
        public PaymentType PaymentType { get; set; }
        public TollGateType Type { get; set; }
        public List<Device> Devices { get; set; }
        public Cashier? CurrentCashier { get; set; }

        public TollGateDTO(int number, PaymentType paymentType, TollGateType type, List<Device> devices, Cashier? currentCashier)
        {
            Number = number;
            PaymentType = paymentType;
            Type = type;
            Devices = devices;
            CurrentCashier = currentCashier;
        }
    }
}
