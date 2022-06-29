using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TollStations.Commands.AdministratorCommands.TollStations;
using TollStations.Core.Locations;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.SystemUsers.Chiefs.Service;
using TollStations.Core.TollStations.Service;

namespace TollStations.ViewModels.AdministratorViewModels
{
    public class AddTollStationDialogViewModel : ViewModelBase
    {
        public Window ThisWindow { get; set; }

        private ObservableCollection<Location> _locationComboBoxItems;

        public ObservableCollection<Location> LocationComboBoxItems
        {
            get
            {
                return _locationComboBoxItems;
            }
            set
            {
                _locationComboBoxItems = value;
                OnPropertyChanged(nameof(LocationComboBoxItems));
            }
        }
        private int _locationCombBoxSelectedIndex;

        public int LocationComboBoxSelectedIndex
        {
            get
            {
                return _locationCombBoxSelectedIndex;
            }
            set
            {
                _locationCombBoxSelectedIndex = value;
                OnPropertyChanged(nameof(LocationComboBoxSelectedIndex));
            }
        }

        public Location GetLocation()
        {
            return LocationComboBoxItems[LocationComboBoxSelectedIndex];
        }
        private void LoadLocationComboBox()
        {
            LocationComboBoxItems = new();
            foreach (var location in _tollStationService.GetLocationsWithoutStations())
            {
                LocationComboBoxItems.Add(location);
            }
        }
        private ObservableCollection<Chief> _chiefComboBoxItems;

        public ObservableCollection<Chief> ChiefComboBoxItems
        {
            get
            {
                return _chiefComboBoxItems;
            }
            set
            {
                _chiefComboBoxItems = value;
                OnPropertyChanged(nameof(ChiefComboBoxItems));
            }
        }
        private int _chiefCombBoxSelectedIndex;

        public int ChiefComboBoxSelectedIndex
        {
            get
            {
                return _chiefCombBoxSelectedIndex;
            }
            set
            {
                _chiefCombBoxSelectedIndex = value;
                OnPropertyChanged(nameof(ChiefComboBoxSelectedIndex));
            }
        }
        public Chief GetChief()
        {
            return ChiefComboBoxItems[ChiefComboBoxSelectedIndex];
        }
        private void LoadChiefComboBox()
        {
            ChiefComboBoxItems = new();
            foreach (Chief chief in _chiefService.GetAllWithoutStations())
            {
                ChiefComboBoxItems.Add(chief);
            }
        }

        public void LoadComboBoxes() {
            LoadChiefComboBox();
            LoadLocationComboBox();
        }

        public ICommand AddTollStationDialogCommand { get; }
        IChiefService _chiefService;
        ITollStationService _tollStationService;

        public AddTollStationDialogViewModel(Window window, ITollStationService tollStationService, IChiefService chiefService)
        {
            ThisWindow = window;
            _chiefService = chiefService;
            _tollStationService = tollStationService;
            LoadComboBoxes();
            AddTollStationDialogCommand = new AddTollStationDialogCommand(this, tollStationService);
        }
    }
}
