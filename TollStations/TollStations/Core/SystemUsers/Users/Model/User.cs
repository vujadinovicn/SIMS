using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStation.Core.Locations;

namespace TollStations.Core.SystemUsers.Users.Model
{
    public class User
    {
        string firstName;
        string lastName;
        int tel;
        string mail;
        string address;
        Location location;
        Account account;

        public User(string firstName, string lastName, int tel, string mail, string address, Location location, Account account)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.tel = tel;
            this.mail = mail;
            this.address = address;
            this.location = location;
            this.account = account;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Tel { get => tel; set => tel = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Address { get => address; set => address = value; }
        public Location Location { get => location; set => location = value; }
        public Account Account { get => account; set => account = value; }
    }
}
