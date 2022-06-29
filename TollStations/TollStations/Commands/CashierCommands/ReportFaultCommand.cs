using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.View.CashierView;

namespace TollStations.Commands.CashierCommands
{
    public class ReportFaultCommand : CommandBase
    {
        Cashier _cashier;
        public ReportFaultCommand(Cashier cashier)
        {
            _cashier = cashier;
        }
        public override void Execute(object? parameter)
        {
            var window = new CashierDeviceValidationWindow(_cashier.TollGate);
            window.ShowDialog();
        }
    }
}
