using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.SystemUsers.Users.Service;
using TollStations.View.AdministratorView;
using TollStations.View.CashierView;
using TollStations.View.ChiefView;
using TollStations.View.ManagerView;
using TollStations.ViewModels;

namespace TollStations.Commands
{
    public class LoginCommand : CommandBase
    {
        private LoginWindowViewModel _loginViewModel;
        private IAccountService _accountService;
        
        public LoginCommand(LoginWindowViewModel loginViewModel, IAccountService accountService)
        {
            _loginViewModel = loginViewModel;
            _accountService = accountService;
        }

        public String ToPlainString(System.Security.SecureString secureStr)
        {
            String plainStr = new System.Net.NetworkCredential(string.Empty, secureStr).Password;
            return plainStr;
        }

        public override void Execute(object? parameter)
        {
            Account account = GetAccountFromInputData();
            if (_accountService.IsUserFound(account, ToPlainString(_loginViewModel.Password)))
            {
                switch (account.UserType)
                {
                    case UserType.CASHIER:
                        RedirectCashier(account);

                        break;

                    case UserType.CHIEF:
                        RedirectChief(account);
                        break;

                    case UserType.MANAGER:
                        RedirectManager();

                        break;

                    case UserType.ADMINISTRATOR:
                        RedirectAdministrator();
                        break;
                }
            }
        }

        private Account GetAccountFromInputData()
        {
            return _accountService.GetByUsername(_loginViewModel.Username);
        }

        private void RedirectCashier(Account foundAccount)
        {
            Cashier cashier = (Cashier)foundAccount.User;
            var window = new CashierInitialWindow(cashier);
            _loginViewModel.ThisWindow.Close();
            window.ShowDialog();
        }

        private void RedirectChief(Account foundAccount)
        {
            Chief chief = (Chief)foundAccount.User;
            var window = new ChiefInitialWindow(chief);
            _loginViewModel.ThisWindow.Close();
            window.ShowDialog();
        }

        private void RedirectManager()
        {
            var window = new ManagerInitialWindow();
            _loginViewModel.ThisWindow.Close();
            window.ShowDialog();
        }

        private void RedirectAdministrator()
        {
           var window = new AdministratorInitialWindow();
           _loginViewModel.ThisWindow.Close();
            window.ShowDialog();
        }
    }
}
