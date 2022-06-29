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
        double _earning;

        public EarningViewModel(VehicleType vehicleType, double earning)
        {
            _vehicleType = vehicleType;
            _earning = earning;
        }

        public string VehicleType => _vehicleType.ToString();
        public double Earning => _earning;
    }
}
