using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Core.SystemUsers.Users.Model
{
    public enum UserType
    {
        CASHIER,
        CHIEF,
        MANAGER,
        ADMINISTRATOR
    }

    public class Account
    {
        string userName;
        string password;
        UserType userType;
        User user;

        public Account(string userName, string password, UserType userType, User user)
        {
            this.userName = userName;
            this.password = password;
            this.userType = userType;
            this.user = user;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public UserType UserType { get => userType; set => userType = value; }
        public User User { get => user; set => user = value; }
    }
}
