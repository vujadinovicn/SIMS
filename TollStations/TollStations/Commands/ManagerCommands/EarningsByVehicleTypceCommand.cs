using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.Reports;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Model;
using TollStations.View.ManagerView;
using TollStations.ViewModels.ManagerViewModels;

namespace TollStations.Commands.ManagerCommands
{
    class EarningsByVehicleTypceCommand : CommandBase
    {
        IEarningsByVehicleTypeReportService reportService;
        ITollStationService tollStationService;
        TollStation station;
        ManagerInitialWindowViewModel managerInitialWindowViewModel;
        public EarningsByVehicleTypceCommand(IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService, ManagerInitialWindowViewModel managerInitialWindowViewModel)
        {
            this.reportService = reportService;
            this.tollStationService = tollStationService;
            this.managerInitialWindowViewModel = managerInitialWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            var window = new EarningsByVehicleTypeWindow(reportService, tollStationService, managerInitialWindowViewModel.GetTollStation());
            window.ShowDialog();
        }
    }
}
