using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.AdministratorCommands.TollStations;
using TollStations.Core;
using TollStations.Core.TollGates;
using TollStations.Core.TollGates.Service;
using TollStations.Core.TollStations.Model;
using TollStations.ViewModels.ModelViewModels;

namespace TollStations.ViewModels.AdministratorViewModels
{
    public class TollGatesTableViewModel : ViewModelBase
    {
        public List<TollGate> TollGates;

        private int _selectedTollGateIndex;

        public int SelectedTollGateIndex
        {
            get
            {
                return _selectedTollGateIndex;
            }
            set
            {
                _selectedTollGateIndex = value;
                OnPropertyChanged(nameof(SelectedTollGateIndex));
            }
        }

        private ObservableCollection<TollGateViewModel> _tollGatesVM;

        public ObservableCollection<TollGateViewModel> TollGatesVM
        {
            get
            {
                return _tollGatesVM;
            }
            set
            {
                _tollGatesVM = value;
                OnPropertyChanged(nameof(TollGatesVM));
            }
        }

        public void RefreshGrid()
        {
            _tollGatesVM.Clear();
            TollGates.Clear();
            foreach (TollGate tollGate in _tollGateService.GetByStation(_tollStation.Id))
            {
                TollGates.Add(tollGate);
                _tollGatesVM.Add(new TollGateViewModel(tollGate));
            }
        }

        public TollGate GetSelectedTollGate()
        {
            return TollGates[_selectedTollGateIndex];
        }

        public ICommand AddTollGateCommand { get; }
        public ICommand EditTollGateCommand { get; }
        public ICommand DeleteTollGateCommand { get; }
        public ICommand TollGatesTableCommand { get; }
        ITollGateService _tollGateService;
        TollStation _tollStation;
        public TollGatesTableViewModel(TollStation tollStation, ITollGateService tollGateService, IRemovingService removingService)
        {
            _tollStation = tollStation;
            _tollGateService = tollGateService;
            AddTollGateCommand = new AddTollGateCommand(this, tollStation);
            EditTollGateCommand = new EditTollGateCommand(this);
            DeleteTollGateCommand = new DeleteTollGateCommand(this, removingService);
            TollGates = new();
            _tollGatesVM = new();
            RefreshGrid();
        }
    }
}
