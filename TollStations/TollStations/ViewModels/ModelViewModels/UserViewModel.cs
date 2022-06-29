using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Locations;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.ViewModels.ModelViewModels
{
    public class UserViewModel : ViewModelBase
    {
        User _user;
        public UserViewModel(User user)
        {
            _user = user;
        }

        public string FirstName => _user.FirstName;
        public string LastName => _user.LastName;
        public int Tel => _user.Tel;
        public string Mail => _user.Mail;
        public string Address => _user.Address + " " + _user.Location.ToString();
        public string Type => _user.Account.UserType.ToString();
        public string Username => _user.Account.Username;
    }
}
