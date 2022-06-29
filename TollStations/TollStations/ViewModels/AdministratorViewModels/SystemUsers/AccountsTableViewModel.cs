using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.SystemUsers.Users.Service;
using TollStations.ViewModels.ModelViewModels;

namespace TollStations.ViewModels.AdministratorViewModels
{
    public class AccountsTableViewModel : ViewModelBase
    {
        IAccountService _accountService;
        public List<Account> Accounts;

        private ObservableCollection<AccountViewModel> _accountsVM;

        public ObservableCollection<AccountViewModel> AccountsVM
        {
            get
            {
                return _accountsVM;
            }
            set
            {
                _accountsVM = value;
                OnPropertyChanged(nameof(AccountsVM));
            }
        }

        public void RefreshGrid()
        {
            _accountsVM.Clear();
            Accounts.Clear();
            foreach (Account account in _accountService.GetAll())
            {
                Accounts.Add(account);
                _accountsVM.Add(new AccountViewModel(account));
            }
        }

        public AccountsTableViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            Accounts = new();
            _accountsVM = new();
            RefreshGrid();
        }
    }
}
