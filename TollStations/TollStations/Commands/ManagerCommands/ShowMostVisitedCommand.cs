using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.ViewModels.ManagerViewModels;

namespace TollStations.Commands.ManagerCommands
{
    class ShowMostVisitedCommand : CommandBase
    {
        private MostVisitedStationsWindowViewModel mostVisitedStationsWindowViewModel;

        public ShowMostVisitedCommand(MostVisitedStationsWindowViewModel mostVisitedStationsWindowViewModel)
        {
            this.mostVisitedStationsWindowViewModel = mostVisitedStationsWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            DateTime start = mostVisitedStationsWindowViewModel.SelectedStartDateTime;
            DateTime end = mostVisitedStationsWindowViewModel.SelectedEndDateTime;
            mostVisitedStationsWindowViewModel.RefreshGrid(start, end);
        }
    }
}
