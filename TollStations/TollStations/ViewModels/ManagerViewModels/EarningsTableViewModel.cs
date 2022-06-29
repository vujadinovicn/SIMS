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
        public ICommand ShowEarningsCommand { get; }


        public EarningsTableViewModel(IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService)
        {
            _reportService = reportService;
            _tollStationService = tollStationService;
            earningsByType = new();
            _earningsVM = new();
            LoadStationsComboBox();
            ShowEarningsCommand = new ShowEarningsCommand(this);
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

        public void RefreshGrid(TollStation tollStation, DateTime start, DateTime end)
        {
            _earningsVM.Clear();
            earningsByType.Clear();
            earningsByType = _reportService.GetAll(tollStation, start, end);

            foreach (KeyValuePair<VehicleType, double> pair in earningsByType)
            {
                _earningsVM.Add(new EarningViewModel(pair.Key, pair.Value));
            }
        }
        #endregion


        #region stationsComboBox
        private ObservableCollection<TollStation> _stationsComboBoxItems;
        public ObservableCollection<TollStation> StationsComboBoxItems
        {
            get
            {
                return _stationsComboBoxItems;
            }
            set
            {
                _stationsComboBoxItems = value;
                OnPropertyChanged(nameof(StationsComboBoxItems));
            }
        }

        private int _stationsCombBoxSelectedIndex;
        public int StationsComboBoxSelectedIndex
        {
            get
            {
                return _stationsCombBoxSelectedIndex;
            }
            set
            {
                _stationsCombBoxSelectedIndex = value;
                OnPropertyChanged(nameof(StationsComboBoxSelectedIndex));
            }
        }

        private void LoadStationsComboBox()
        {
            StationsComboBoxItems = new();
            foreach (TollStation tollStation in _tollStationService.GetAll())
            {
                StationsComboBoxItems.Add(tollStation);
            }
        }

        public TollStation GetTollStation()
        {
            return StationsComboBoxItems[StationsComboBoxSelectedIndex];
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
