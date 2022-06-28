using System.Windows.Input;
using TollStations.Commands.AdministratorCommands.AdministratorWindow;

namespace TollStations.ViewModels.DoctorViewModels
{
    public class AdministratorWindowViewModel : ViewModelBase
    {
        public AdministratorWindowViewModel()
        {
            UsersTableCommand = new UsersTableCommand();
            TollSectionsTableCommand = new TollSectionsTableCommand();
            TollGatesTableCommand = new TollGatesTableCommand();
            AccountsTableCommand = new AccountsTableCommand();
        }

        public ICommand UsersTableCommand { get; }
        public ICommand TollSectionsTableCommand { get; }
        public ICommand TollGatesTableCommand { get; }
        public ICommand AccountsTableCommand { get; }
    }
}
