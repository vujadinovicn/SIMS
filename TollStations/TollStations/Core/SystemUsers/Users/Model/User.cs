using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Locations;

namespace TollStations.Core.SystemUsers.Users.Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Tel { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public Location Location { get; set; }
        public Account Account { get; set; }

        public User(string firstName, string lastName, int tel, string mail, string address, Location location, Account account)
        {
            FirstName = firstName;
            LastName = lastName;
            Tel = tel;
            Mail = mail;
            Address = address;
            Location = location;
            Account = account;
        }
    }
}
