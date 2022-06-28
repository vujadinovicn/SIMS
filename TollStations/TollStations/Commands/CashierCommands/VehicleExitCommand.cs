using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.View.CashierView;

namespace TollStations.Commands.CashierCommands
{
    public class VehicleExitCommand : CommandBase
    {
        Cashier _loggedCashier;
        public VehicleExitCommand(Cashier cashier)
        {
            _loggedCashier = cashier;
        }
        public override void Execute(object? parameter)
        {
            var window = new VehicleExitWindow(_loggedCashier);
            window.ShowDialog();
        }
    }
}
