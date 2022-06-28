using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.View.ManagerView;

namespace TollStations.Commands.ManagerCommands
{
    class MostVisitedStationsCommand : CommandBase
    {
        public MostVisitedStationsCommand()
        {
        }

        public override void Execute(object? parameter)
        {
            var window = new MostVisitedStationsWindow();
            window.ShowDialog();
        }
    }
}
