using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.ManagerCommands;
using TollStations.Core.Prices.Model;
using TollStations.Core.Reports;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Model;

namespace TollStations.ViewModels
{
    class EarningsTableViewModel : ViewModelBase
    {
        private Dictionary<VehicleType, double> earningsByType;
        private ObservableCollection<EarningViewModel> _earningsVM;
        IEarningsByVehicleTypeReportService _reportService;
        ITollStationService _tollStationService;
        TollStation _station;
        public ICommand ShowEarningsCommand { get; }


        public EarningsTableViewModel(IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService, TollStation station)
        {
            _reportService = reportService;
            _tollStationService = tollStationService;
            earningsByType = new();
            _earningsVM = new();
            ShowEarningsCommand = new ShowEarningsCommand(this);
            _station = station;
            //RefreshGrid();
        }



        #region table
        public ObservableCollection<EarningViewModel> EarningsVM
        {
            get
            {
                return _earningsVM;
            }
            set
            {
                _earningsVM = value;
                OnPropertyChanged(nameof(EarningsVM));
            }
        }

        public void RefreshGrid(DateTime start, DateTime end)
        {
            _earningsVM.Clear();
            earningsByType.Clear();
            earningsByType = _reportService.GetAll(_station, start, end);

            foreach (KeyValuePair<VehicleType, double> pair in earningsByType)
            {
                _earningsVM.Add(new EarningViewModel(pair.Key, pair.Value));
            }
        }
        #endregion


        #region selectedDates
        private DateTime _selectedStartDateTime = DateTime.Now;
        public DateTime SelectedStartDateTime
        {
            get
            {
                return _selectedStartDateTime;
            }
            set
            {
                _selectedStartDateTime = value;
                OnPropertyChanged(nameof(SelectedStartDateTime));
            }
        }
        private DateTime _selectedEndDateTime = DateTime.Now;
        public DateTime SelectedEndDateTime
        {
            get
            {
                return _selectedEndDateTime;
            }
            set
            {
                _selectedEndDateTime = value;
                OnPropertyChanged(nameof(SelectedEndDateTime));
            }
        }
        #endregion
    }
}
