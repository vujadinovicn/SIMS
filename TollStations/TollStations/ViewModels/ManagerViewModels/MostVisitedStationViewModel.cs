using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;

namespace TollStations.ViewModels.ManagerViewModels
{
    class MostVisitedStationViewModel : ViewModelBase
    {
        TollStation _station;
        int _numOfPayments;

        public MostVisitedStationViewModel(TollStation station, int numOfPayments)
        {
            _station = station;
            _numOfPayments = numOfPayments;
        }

        public string Station => _station.ToString();
        public int NumOfPayments => _numOfPayments;
    }
}
