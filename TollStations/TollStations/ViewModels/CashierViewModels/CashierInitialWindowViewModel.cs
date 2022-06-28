using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.CashierCommands;
using TollStations.Core.SystemUsers.Cashiers.Model;

namespace TollStations.ViewModels.CashierViewModels
{
    public class CashierInitialWindowViewModel : ViewModelBase
    {
        public CashierInitialWindowViewModel(Cashier cashier)
        {
            VehicleEntryCommand = new VehicleEntryCommand(cashier);
            VehicleExitCommand = new VehicleExitCommand(cashier);
        }

        public ICommand VehicleEntryCommand { get; }
        public ICommand VehicleExitCommand { get; }
    }
}
