using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Reports;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.TollStations;
using TollStations.View.ManagerView;
using TollStations.ViewModels.ChiefViewModels;

namespace TollStations.Commands.ChiefCommands
{
    public class EarningsReportCommand : CommandBase
    {
        Chief _loggedChief;
        IEarningsByVehicleTypeReportService _reportService;
        ITollStationService _tollStationService;
        public EarningsReportCommand(Chief chief, IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService)
        {
            _loggedChief = chief;
            _tollStationService = tollStationService;
            _reportService = reportService;

        }
        public override void Execute(object? parameter)
        {
            var window = new EarningsByVehicleTypeWindow(_reportService, _tollStationService, _loggedChief.TollStation);
            window.ShowDialog();
        }
    }
}
