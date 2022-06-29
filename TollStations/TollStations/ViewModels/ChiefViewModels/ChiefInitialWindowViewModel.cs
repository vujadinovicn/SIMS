using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TollStations.Commands.ChiefCommands;
using TollStations.Core.SystemUsers.Chiefs.Model;

namespace TollStations.ViewModels.ChiefViewModels
{
    public class ChiefInitialWindowViewModel : ViewModelBase
    {
        public ChiefInitialWindowViewModel(Chief chief)
        {
            DeviceValidationCommand = new DeviceValidationCommand(chief.TollStation);
            EarningsReportCommand = new EarningsReportCommand(chief);
        }

        public ICommand DeviceValidationCommand { get; }
        public ICommand EarningsReportCommand { get; }
    }
}
