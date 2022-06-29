using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.TollStations.Model;
using TollStations.View.ChiefView;

namespace TollStations.Commands.ChiefCommands
{
    public class DeviceValidationCommand : CommandBase
    {
        TollStation _station;
        public DeviceValidationCommand(TollStation tollStation)
        {
            _station = tollStation;
        }
        public override void Execute(object? parameter)
        {

            var window = new DeviceValidationWindow(_station);
            window.ShowDialog();
        }
    }
}
