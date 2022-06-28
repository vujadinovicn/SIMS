using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Prices.Model;

namespace TollStations.ViewModels
{
    class EarningViewModel : ViewModelBase
    {
        VehicleType _vehicleType;
        int _earning;

        public EarningViewModel(VehicleType vehicleType, int earning)
        {
            _vehicleType = vehicleType;
            _earning = earning;
        }

        public string VehicleType => _vehicleType.ToString();
        public int Earning => _earning;
    }
}
