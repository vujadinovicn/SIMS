using TollStations.Core.Reports;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels.ChiefViewModels;

namespace TollStations.Commands.ChiefCommands
{
    internal class EarningsByVehicleTypceWindow
    {
        private IEarningsByVehicleTypeReportService reportService;
        private ITollStationService tollStationService;
        private TollStation tollStation;

        public EarningsByVehicleTypceWindow(IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService, TollStation tollStation)
        {
            this.reportService = reportService;
            this.tollStationService = tollStationService;
            this.tollStation = tollStation;
        }
    }
}