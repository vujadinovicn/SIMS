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
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels.ModelViewModels;

namespace TollStations.ViewModels.AdministratorViewModels
{
    public class TollStationsCashiersTableViewModel : ViewModelBase
    {
        public List<User> Users;

        private ObservableCollection<UserViewModel> _usersVM;

        public ObservableCollection<UserViewModel> UsersVM
        {
            get
            {
                return _usersVM;
            }
            set
            {
                _usersVM = value;
                OnPropertyChanged(nameof(UsersVM));
            }
        }

        public void RefreshGrid()
        {
            _usersVM.Clear();
            Users.Clear();
            foreach (User user in _cashierService.GetByStation(_tollStation.Id))
            {
                Users.Add(user);
                _usersVM.Add(new UserViewModel(user));
            }
            LoadCashierComboBox();
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
            return (Cashier)CashierComboBoxItems[CashierComboBoxSelectedIndex];
        }

        public TollStation GetTollStation()
        {
            return _tollStation;
        }
        private void LoadCashierComboBox()
        {
            CashierComboBoxItems = new();
            foreach (var cashier in _cashierService.GetAllWithoutStations())
            {
                CashierComboBoxItems.Add(cashier);
            }
            CashierComboBoxSelectedIndex = 0;
        }

        TollStation _tollStation;
        ITollStationService _tollStationService;
        ICashierService _cashierService;
        public ICommand AddTollStationsCashierDialogCommand { get; }
        public TollStationsCashiersTableViewModel(TollStation tollStation, ITollStationService tollStationService, ICashierService cashierService)
        {
            _tollStation = tollStation;
            _tollStationService = tollStationService;
            _cashierService = cashierService;
            Users = new();
            _usersVM = new();
            AddTollStationsCashierDialogCommand = new AddTollStationsCashierDialogCommand(this, cashierService);
            RefreshGrid();
        }
    }
}
