using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.View;

namespace TollStations.Commands
{
    public class LogoutCommand : CommandBase
    {
        public Window Window { get; set; }
        public LogoutCommand(Window window)
        {
            Window = window;
        }

        public override void Execute(object? parameter)
        {
            if (System.Windows.MessageBox.Show("Are you sure you want to log out?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Window.Close();
                var window = DIContainer.GetService<LoginWindow>();
                window.ShowDialog();
            }
        }
    }
}