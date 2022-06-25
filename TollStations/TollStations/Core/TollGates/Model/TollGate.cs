using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStation.Core.Devices;
using TollStation.Core.SystemUsers.Cashiers;
using TollStations.Core.TollGates.Model;

namespace TollStation.Core.TollGates
{
    public class TollGate
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public PaymentType PaymentType { get; set; }
        public TollGateType Type { get; set; }
        public List<Device> Devices { get; set; }
        public Cashier? CurrentCashier { get; set; }

        public TollGate(int id, int number, PaymentType paymentType, TollGateType type, List<Device> devices, Cashier? currentCashier)
        {
            Id = id;
            Number = number;
            PaymentType = paymentType;
            Type = type;
            Devices = devices;
            CurrentCashier = currentCashier;
        }

        public TollGate(TollGateDTO tollGateDTO)
        {
            Number = tollGateDTO.Number;
            PaymentType = tollGateDTO.PaymentType;
            Type = tollGateDTO.Type;
            Devices = tollGateDTO.Devices;
            CurrentCashier = tollGateDTO.CurrentCashier;
        }
    }

    public enum TollGateType
    {
        Entry,
        Exit
    }

    public enum PaymentType
    {
        Electronic,
        Physical
    }
}
