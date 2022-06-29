using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TollStations.Core.Devices.Service;
using TollStations.Core.TollStations.Model;
using TollStations.ViewModels.ChiefViewModels;

namespace TollStations.View.ChiefView
{
    /// <summary>
    /// Interaction logic for DeviceValidationWindow.xaml
    /// </summary>
    public partial class DeviceValidationWindow : Window
    {
        public DeviceValidationWindow(TollStation tollStation)
        {
            InitializeComponent();
            DataContext = new DeviceValidationWindowViewModel(tollStation, DIContainer.GetService<IDeviceService>());
        }
    }
}
