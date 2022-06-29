using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.ChiefCommands;
using TollStations.Core.Reports;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.TollStations;

namespace TollStations.ViewModels.ChiefViewModels
{
    public class ChiefInitialWindowViewModel : ViewModelBase
    {
        public ChiefInitialWindowViewModel(Chief chief, IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService)
        {
            DeviceValidationCommand = new DeviceValidationCommand(chief.TollStation);
            EarningsReportCommand = new EarningsReportCommand(chief, reportService, tollStationService);
        }

        public ICommand DeviceValidationCommand { get; }
        public ICommand EarningsReportCommand { get; }
    }
}
