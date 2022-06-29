using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.AdministratorCommands.TollStations;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.SystemUsers.Cashiers.Service;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.SystemUsers.Chiefs.Service;
using TollStations.Core.TollGates;
using TollStations.Core.TollGates.Service;
using TollStations.Core.TollStations.Service;

namespace TollStations.ViewModels.AdministratorViewModels
{
    public class AddTollGateDialogViewModel : ViewModelBase
    {

        private string _number;

        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public int GetNumber()
        {
            return Int32.Parse(Number);
        }
        private ObservableCollection<string> _typeComboBoxItems;

        public ObservableCollection<string> TypeComboBoxItems
        {
            get
            {
                return _typeComboBoxItems;
            }
            set
            {
                _typeComboBoxItems = value;
                OnPropertyChanged(nameof(TypeComboBoxItems));
            }
        }
        private int _typeCombBoxSelectedIndex;

        public int TypeComboBoxSelectedIndex
        {
            get
            {
                return _typeCombBoxSelectedIndex;
            }
            set
            {
                _typeCombBoxSelectedIndex = value;
                OnPropertyChanged(nameof(TypeComboBoxSelectedIndex));
            }
        }

        public TollGateType GetType()
        {
            return (TollGateType)TypeComboBoxSelectedIndex;
        }
        private void LoadTypeComboBox()
        {
            TypeComboBoxItems = new();
            TypeComboBoxItems.Add("Entry");
            TypeComboBoxItems.Add("Exit");
            TypeComboBoxSelectedIndex = 0;
        }
        private ObservableCollection<Cashier> _cashierComboBoxItems;

        public ObservableCollection<Cashier> CashierComboBoxItems
        {
            get
            {
                return _cashierComboBoxItems;
            }
            set
            {
                _cashierComboBoxItems = value;
                OnPropertyChanged(nameof(CashierComboBoxItems));
            }
        }
        private int _cashierCombBoxSelectedIndex;

        public int CashierComboBoxSelectedIndex
        {
            get
            {
                return _cashierCombBoxSelectedIndex;
            }
            set
            {
                _cashierCombBoxSelectedIndex = value;
                OnPropertyChanged(nameof(CashierComboBoxSelectedIndex));
            }
        }
        public Cashier GetCashier()
        {
            return CashierComboBoxItems[CashierComboBoxSelectedIndex];
        }
        private void LoadCashierComboBox()
        {
            CashierComboBoxItems = new();
            foreach (Cashier cashier in _cashierService.GetAll())
            {
                CashierComboBoxItems.Add(cashier);
            }
        }

        public void LoadComboBoxes()
        {
            LoadCashierComboBox();
            LoadTypeComboBox();
        }

        public ICommand AddTollStationDialogCommand { get; }
        ICashierService _cashierService;
        ITollGateService _tollGateService;

        public AddTollGateDialogViewModel(ITollGateService tollGateService, ICashierService cashierService)
        {
            _cashierService = cashierService;
            _tollGateService = tollGateService;
            LoadComboBoxes();
            AddTollStationDialogCommand = new AddTollGateDialogCommand(this, tollGateService);
        }
    }
}
