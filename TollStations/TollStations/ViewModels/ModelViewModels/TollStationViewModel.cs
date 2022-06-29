using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;

namespace TollStations.ViewModels.ModelViewModels
{
    public class TollStationViewModel : ViewModelBase
    {
        TollStation _tollStation;
        public TollStationViewModel(TollStation tollStation)
        {
            _tollStation = tollStation;
        }

        public string Chief => _tollStation.Chief.FirstName + " " + _tollStation.Chief.LastName;
        public string Location => _tollStation.Location.ToString();
    }
}