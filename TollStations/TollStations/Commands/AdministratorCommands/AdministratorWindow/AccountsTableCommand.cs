using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.View.AdministratorView;

namespace TollStations.Commands.AdministratorCommands.AdministratorWindow
{
    public class AccountsTableCommand : CommandBase
    {
        public AccountsTableCommand()
        {
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<AccountsTable>();
            window.ShowDialog();
        }
    }
}
