using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.View.ManagerView;

namespace TollStations.Commands.ManagerCommands
{
    class PricelistCommand : CommandBase
    {

        public override void Execute(object? parameter)
        {
            PricelistWindow pricelistWindow = new PricelistWindow();
            pricelistWindow.ShowDialog();
        }
    }
}
