using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Locations;
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.TollGates;
using TollStations.Core.TollStations.Model;

namespace TollStations.Core.SystemUsers.Cashiers.Model
{
    public class Cashier : User
    {
        public TollGate? TollGate { get; set; }
        public TollStation TollStation { get; set; }
        public Cashier(int id, string firstName, string lastName, int tel, string mail, string address, Location location, Account account, TollGate tollGate, TollStation tollStation) : base(id, firstName, lastName, tel, mail, address, location, account)
        {
            this.TollGate = tollGate;
            this.TollStation = tollStation;
        }
    }
}
