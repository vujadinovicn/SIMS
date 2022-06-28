using System.Windows.Input;
using TollStations.Commands.AdministratorCommands.AdministratorWindow;

namespace TollStations.ViewModels.DoctorViewModels
{
    public class AdministratorWindowViewModel : ViewModelBase
    {
        public AdministratorWindowViewModel()
        {
            UsersTableCommand = new UsersTableCommand();
            TollStationsTableCommand = new TollStationsTableCommand();
            AccountsTableCommand = new AccountsTableCommand();
        }

        public ICommand UsersTableCommand { get; }
        public ICommand TollStationsTableCommand { get; }
        public ICommand AccountsTableCommand { get; }
    }
}
