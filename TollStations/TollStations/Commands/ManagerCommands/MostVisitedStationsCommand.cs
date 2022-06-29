using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Reports;
using TollStations.View.ManagerView;

namespace TollStations.Commands.ManagerCommands
{
    class MostVisitedStationsCommand : CommandBase
    {
        IMostVisitedStationsReportService mostVisitedReoportService;
        public MostVisitedStationsCommand(IMostVisitedStationsReportService mostVisitedReoportService)
        {
            this.mostVisitedReoportService = mostVisitedReoportService;
        }

        public override void Execute(object? parameter)
        {
            var window = new MostVisitedStationsWindow(mostVisitedReoportService);
            window.ShowDialog();
        }
    }
}
