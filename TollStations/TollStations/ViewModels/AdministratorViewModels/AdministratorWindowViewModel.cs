using System.Windows;
using System.Windows.Input;
using TollStations.Commands;
using TollStations.Commands.AdministratorCommands.AdministratorWindow;

namespace TollStations.ViewModels.DoctorViewModels
{
    public class AdministratorWindowViewModel : ViewModelBase
    {
        public AdministratorWindowViewModel(Window window)
        {
            UsersTableCommand = new UsersTableCommand();
            TollStationsTableCommand = new TollStationsTableCommand();
            AccountsTableCommand = new AccountsTableCommand();
            LogoutCommand = new LogoutCommand(window);
        }

        public ICommand UsersTableCommand { get; }
        public ICommand TollStationsTableCommand { get; }
        public ICommand AccountsTableCommand { get; }
        public ICommand LogoutCommand { get; }
    }
}
