using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.AdministratorCommands.TollStations;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels.ModelViewModels;

namespace TollStations.ViewModels.AdministratorViewModels
{
    public class TollStationsTableViewModel : ViewModelBase
    {
        public List<TollStation> TollStations;

        private int _selectedTollStationIndex;

        public int SelectedTollStationIndex
        {
            get
            {
                return _selectedTollStationIndex;
            }
            set
            {
                _selectedTollStationIndex = value;
                OnPropertyChanged(nameof(SelectedTollStationIndex));
            }
        }

        private ObservableCollection<TollStationViewModel> _tollStationsVM;

        public ObservableCollection<TollStationViewModel> TollStationsVM
        {
            get
            {
                return _tollStationsVM;
            }
            set
            {
                _tollStationsVM = value;
                OnPropertyChanged(nameof(TollStationsVM));
            }
        }

        public void RefreshGrid()
        {
            _tollStationsVM.Clear();
            TollStations.Clear();
            foreach (TollStation tollStation in _tollStationService.GetAll())
            {
                TollStations.Add(tollStation);
                _tollStationsVM.Add(new TollStationViewModel(tollStation));
            }
        }

        public TollStation GetSelectedTollStation()
        {
            return TollStations[_selectedTollStationIndex];
        }

        public ICommand AddTollStationCommand { get; }
        public ICommand EditTollStationCommand { get; }
        public ICommand DeleteTollStationCommand { get; }
        public ICommand TollGatesTableCommand { get;  }
        ITollStationService _tollStationService;
        public TollStationsTableViewModel(ITollStationService tollStationService)
        {
            _tollStationService = tollStationService;
            AddTollStationCommand = new AddTollStationCommand(this);
            EditTollStationCommand = new EditTollStationCommand(this);
            DeleteTollStationCommand = new DeleteTollStationCommand(this, tollStationService);
            TollGatesTableCommand = new TollGatesTableCommand(this);
            TollStations = new();
            _tollStationsVM = new();
            RefreshGrid();
        }
    }
}
