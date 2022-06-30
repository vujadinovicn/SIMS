using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.ViewModels.ModelViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        Account _account;
        public AccountViewModel(Account account)
        {
            _account = account;
        }

        public string Username => _account.Username;
        public string Password => _account.Password;
        public string Type => _account.UserType.ToString();
    }
}