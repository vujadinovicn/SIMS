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
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public User? User { get; set; }

        public Account(int id, string username, string password, UserType userType, User? user)
        {
            Id = id;
            Username = username;
            Password = password;
            UserType = userType;
            User = user;
        }
    }
}
