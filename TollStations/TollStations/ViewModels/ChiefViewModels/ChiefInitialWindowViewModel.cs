using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TollStations.Commands;
using TollStations.Commands.ChiefCommands;
using TollStations.Core.Reports;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Service;

namespace TollStations.ViewModels.ChiefViewModels
{
    public class ChiefInitialWindowViewModel : ViewModelBase
    {
        IEarningsByVehicleTypeReportService _earningsByVehicleTypeReportService;
        ITollStationService _tollStationService;
        public ChiefInitialWindowViewModel(IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService)
        {
            _earningsByVehicleTypeReportService = reportService;
            _tollStationService = tollStationService;
        }

        public void SetChief(Chief chief)
        {
            DeviceValidationCommand = new DeviceValidationCommand(chief.TollStation);
            EarningsReportCommand = new EarningsReportCommand(chief, _earningsByVehicleTypeReportService, _tollStationService);
        }

        public void SetWindow(Window window)
        {
            LogoutCommand = new LogoutCommand(window);
        }
        public ICommand LogoutCommand { get; set; }
        public ICommand DeviceValidationCommand { get; set; }
        public ICommand EarningsReportCommand { get; set; }
        
    }
}
