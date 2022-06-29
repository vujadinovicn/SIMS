using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.ChiefCommands;
using TollStations.Commands.ManagerCommands;
using TollStations.Core.Reports;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Model;

namespace TollStations.ViewModels.ManagerViewModels
{
    public class ManagerInitialWindowViewModel : ViewModelBase
    {
        ITollStationService _stationService;
        public ManagerInitialWindowViewModel(IMostVisitedStationsReportService mostVisitedReoportService, IEarningsByVehicleTypeReportService earningsReportService, ITollStationService tollStationService)
        {
            EarningsByVehicleTypeCommand = new EarningsByVehicleTypceCommand(earningsReportService, tollStationService, this);
            MostVisitedStationsCommand = new MostVisitedStationsCommand(mostVisitedReoportService);
            PricelistCommand = new PricelistCommand();
            ManagerDeviceValidationCommand = new ManagerDeviceValidationCommand(this);
            _stationService = tollStationService;
            LoadTollStationComboBox();
        }

        public ICommand EarningsByVehicleTypeCommand { get; }
        public ICommand MostVisitedStationsCommand { get; }
        public ICommand PricelistCommand { get; }
        public ICommand ManagerDeviceValidationCommand { get; }

        private ObservableCollection<TollStation> _tollStationComboBoxItems;

        public ObservableCollection<TollStation> TollStationComboBoxItems
        {
            get
            {
                return _tollStationComboBoxItems;
            }
            set
            {
                _tollStationComboBoxItems = value;
                OnPropertyChanged(nameof(TollStationComboBoxItems));
            }
        }
        private int _tollStationCombBoxSelectedIndex;

        public int TollStationComboBoxSelectedIndex
        {
            get
            {
                return _tollStationCombBoxSelectedIndex;
            }
            set
            {
                _tollStationCombBoxSelectedIndex = value;
                OnPropertyChanged(nameof(TollStationComboBoxSelectedIndex));
            }
        }


        public TollStation GetTollStation()
        {
            return TollStationComboBoxItems[TollStationComboBoxSelectedIndex];
        }

        private void LoadTollStationComboBox()
        {
            TollStationComboBoxItems = new();
            foreach (TollStation station in _stationService.GetAll())
            {
                TollStationComboBoxItems.Add(station);
            }
            TollStationComboBoxSelectedIndex = 0;
        }
    }
}
