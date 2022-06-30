using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.View.AdministratorView;

namespace TollStations.Commands.AdministratorCommands.AdministratorWindow
{
    public class TollStationsTableCommand : CommandBase
    {
        public TollStationsTableCommand()
        {
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<TollStationsTable>();
            window.ShowDialog();
        }
    }
}
