﻿using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.View.AdministratorView;

namespace TollStations.Commands.AdministratorCommands.AdministratorWindow
{
    public class TollGatesTableCommand : CommandBase
    {
        public TollGatesTableCommand()
        {
        }
        public override void Execute(object? parameter)
        {
            var window = DIContainer.GetService<TollGatesTable>();
            window.ShowDialog();
        }
    }
}
