using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStation.Core.Locations;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.Core.SystemUsers.Cashiers.Model
{
    public class Cashier : User
    {
        public Cashier(string firstName, string lastName, int tel, string mail, string address, UserType userType, Location location) : base(firstName, lastName, tel, mail, address, userType, location)
        {
        }
    }
}
