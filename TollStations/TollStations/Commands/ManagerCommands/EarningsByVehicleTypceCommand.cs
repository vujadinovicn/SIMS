using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Reports;
using TollStations.Core.TollStations;
using TollStations.View.ManagerView;

namespace TollStations.Commands.ManagerCommands
{
    class EarningsByVehicleTypceCommand : CommandBase
    {
        IEarningsByVehicleTypeReportService reportService;
        ITollStationService tollStationService;
        public EarningsByVehicleTypceCommand(IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService)
        {
            this.reportService = reportService;
            this.tollStationService = tollStationService;
        }

        public override void Execute(object? parameter)
        {
            var window = new EarningsByVehicleTypeWindow(reportService, tollStationService);
            window.ShowDialog();
        }
    }
}
