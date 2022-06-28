using System.Windows.Input;
using TollStations.Commands.AdministratorCommands.AdministratorWindow;

namespace TollStations.ViewModels.DoctorViewModels
{
    public class AdministratorWindowViewModel : ViewModelBase
    {
        public AdministratorWindowViewModel()
        {
            CashiersTableCommand = new CashiersTableCommand();
            ChiefsTableCommand = new ChiefsTableCommand();
            ManagersTableCommand = new ManagersTableCommand();
            TollSectionsTableCommand = new TollSectionsTableCommand();
            TollGatesTableCommand = new TollGatesTableCommand();
        }

        public ICommand CashiersTableCommand { get; }
        public ICommand ChiefsTableCommand { get; }
        public ICommand ManagersTableCommand { get; }
        public ICommand TollSectionsTableCommand { get; }
        public ICommand TollGatesTableCommand { get; }
    }
}
