using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Locations;
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.TollGates;

namespace TollStations.Core.SystemUsers.Cashiers.Model
{
    public class Cashier : User
    {
        public TollGate? TollGate { get; set; }
        public Cashier(string firstName, string lastName, int tel, string mail, string address, UserType userType, Location location, Account account, TollGate tollGate) : base(firstName, lastName, tel, mail, address, location, account)
        {
            this.TollGate = tollGate;
        }
    }
}
