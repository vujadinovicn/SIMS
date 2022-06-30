using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.ManagerCommands;
using TollStations.Core.Reports;
using TollStations.Core.TollStations.Model;

namespace TollStations.ViewModels.ManagerViewModels
{
    class MostVisitedStationsWindowViewModel : ViewModelBase
    {
        private Dictionary<TollStation, int> paymentsByStation;
        private ObservableCollection<MostVisitedStationViewModel> _visitsVM;
        private IMostVisitedStationsReportService _reportService;
        public ICommand ShowMostVisitedCommand { get; }

        public MostVisitedStationsWindowViewModel(IMostVisitedStationsReportService reportService)
        {
            paymentsByStation = new();
            _visitsVM = new();
            _reportService = reportService;
            ShowMostVisitedCommand = new ShowMostVisitedCommand(this);
        }

        #region table
        public ObservableCollection<MostVisitedStationViewModel> VisitsVM
        {
            get
            {
                return _visitsVM;
            }
            set
            {
                _visitsVM = value;
                OnPropertyChanged(nameof(VisitsVM));
            }
        }

        public void RefreshGrid(DateTime start, DateTime end)
        {
            _visitsVM.Clear();
            paymentsByStation.Clear();
            paymentsByStation = _reportService.GetAll(start, end);

            foreach (KeyValuePair<TollStation, int> pair in paymentsByStation)
            {
                _visitsVM.Add(new MostVisitedStationViewModel(pair.Key, pair.Value));
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
