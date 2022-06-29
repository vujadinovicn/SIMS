using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TollStations.Commands;
using TollStations.Core.SystemUsers.Users.Service;

namespace TollStations.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public ICommand Login { get; }
        public Window ThisWindow;
        private string _username;

        IAccountService _accountService;
        
        public LoginWindowViewModel(Window loginWindow, IAccountService accountService)
        {
            this.ThisWindow = loginWindow;
            Login = new LoginCommand(this, accountService);
            _accountService = accountService;
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private SecureString _password;

        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}
