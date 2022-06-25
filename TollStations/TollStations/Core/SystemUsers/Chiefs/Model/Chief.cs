using TollStations.Core.TollStations.Model;
using TollStations.Core.Locations;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.Core.SystemUsers.Chiefs.Model
{
    public class Chief : User
    {
        public TollStation TollStation { get; set; }

        public Chief(int id, string firstName, string lastName, int tel, string mail, string address, Location location, Account account, TollStation tollStation) : base(id, firstName, lastName, tel, mail, address, location, account)
        {
            this.TollStation = tollStation;
        }

    }
}
