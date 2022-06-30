using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollGates;

namespace TollStations.ViewModels.ModelViewModels
{
    public class TollGateViewModel : ViewModelBase
    {
        TollGate _tollGate;

        public TollGateViewModel(TollGate tollGate)
        {
            this._tollGate = tollGate;
        }
        public string Number => _tollGate.Number.ToString();
        public string PaymentType => _tollGate.PaymentType.ToString();
        public string Type => _tollGate.Type.ToString();
        public string CurrentCashier => _tollGate.CurrentCashier.FirstName + " " + _tollGate.CurrentCashier.LastName;
    
    }
}
