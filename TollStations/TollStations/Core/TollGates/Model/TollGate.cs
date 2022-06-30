using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Devices;
using TollStations.Core.SystemUsers.Cashiers;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollGates.Model;
using TollStations.Core.TollPayments.Model;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.TollGates
{
    public class TollGate
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public PaymentType PaymentType { get; set; }
        public TollGateType Type { get; set; }
        public List<Device> Devices { get; set; }
        public Cashier? CurrentCashier { get; set; }
        public List<TollPayment> TollPayments { get; set; }
        public TollStation TollStation { get; set; }
        public TollGate(int id, int number, PaymentType paymentType, TollGateType type, List<Device> devices, Cashier? currentCashier, List<TollPayment> tollPayments, TollStation tollStation)
        {
            Id = id;
            Number = number;
            PaymentType = paymentType;
            Type = type;
            Devices = devices;
            CurrentCashier = currentCashier;
            TollPayments = tollPayments;
            TollStation = tollStation;
        }

        public TollGate(TollGateDTO tollGateDTO)
        {
            Number = tollGateDTO.Number;
            PaymentType = tollGateDTO.PaymentType;
            Type = tollGateDTO.Type;
            Devices = tollGateDTO.Devices;
            CurrentCashier = tollGateDTO.CurrentCashier;
            TollPayments = tollGateDTO.TollPayments;
            TollStation = tollGateDTO.TollStation;
        }

        public override string? ToString()
        {
            return "Gate number "+Number;
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
