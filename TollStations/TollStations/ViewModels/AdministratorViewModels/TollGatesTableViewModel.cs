using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollGates;
using TollStations.Core.TollGates.Service;
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
            foreach (TollGate tollGate in _tollGateService.GetAll())
            {
                TollGates.Add(tollGate);
                _tollGatesVM.Add(new TollGateViewModel(tollGate));
            }
        }

        public TollGate GetSelectedTollGate()
        {
            return TollGates[_selectedTollGateIndex];
        }

        //public ICommand AddTollGateCommand { get; }
        //public ICommand EditTollGateCommand { get; }
        //public ICommand DeleteTollGateCommand { get; }
        //public ICommand TollGatesTableCommand { get; }
        ITollGateService _tollGateService;
        public TollGatesTableViewModel(ITollGateService tollGateService)
        {
            _tollGateService = tollGateService;
            //AddTollGateCommand = new AddTollGateCommand();
            //EditTollGateCommand = new EditTollGateCommand();
            //DeleteTollGateCommand = new DeleteTollGateCommand();
            //TollGatesTableCommand = new TollGatesTableCommand();
            TollGates = new();
            _tollGatesVM = new();
            RefreshGrid();
        }
    }
}
