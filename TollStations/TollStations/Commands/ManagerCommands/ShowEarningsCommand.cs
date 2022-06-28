using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.TollStations.Model;
using TollStations.ViewModels;

namespace TollStations.Commands.ManagerCommands
{
    class ShowEarningsCommand : CommandBase
    {
        private EarningsTableViewModel earningsTableViewModel;

        public ShowEarningsCommand(EarningsTableViewModel earningsTableViewModel)
        {
            this.earningsTableViewModel = earningsTableViewModel;
        }

        public override void Execute(object? parameter)
        {
            DateTime start = earningsTableViewModel.SelectedStartDateTime;
            DateTime end = earningsTableViewModel.SelectedEndDateTime;
            TollStation tollStation = earningsTableViewModel.GetTollStation();
            earningsTableViewModel.RefreshGrid(tollStation, start, end);
        }
    }
}
