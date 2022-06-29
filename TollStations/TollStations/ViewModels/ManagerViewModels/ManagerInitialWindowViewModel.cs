using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.ManagerCommands;
using TollStations.Core.Reports;
using TollStations.Core.TollStations;

namespace TollStations.ViewModels.ManagerViewModels
{
    public class ManagerInitialWindowViewModel : ViewModelBase
    {
        public ManagerInitialWindowViewModel(IMostVisitedStationsReportService mostVisitedReoportService, IEarningsByVehicleTypeReportService earningsReportService, ITollStationService tollStationService)
        {
            EarningsByVehicleTypeCommand = new EarningsByVehicleTypceCommand(earningsReportService, tollStationService);
            MostVisitedStationsCommand = new MostVisitedStationsCommand(mostVisitedReoportService);
        }

        public ICommand EarningsByVehicleTypeCommand { get; }
        public ICommand MostVisitedStationsCommand { get; }
    }
}
