using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Chiefs.Model;

namespace TollStations.Commands.ChiefCommands
{
    public class EarningsReportCommand : CommandBase
    {
        Chief _loggedChief;
        public EarningsReportCommand(Chief chief)
        {
            _loggedChief = chief;
        }
        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
