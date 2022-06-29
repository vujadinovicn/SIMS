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
using TollStations.Core.TollGates;
using TollStations.ViewModels.CashierViewModels;

namespace TollStations.View.CashierView
{
    /// <summary>
    /// Interaction logic for CashierDeviceValidationWindow.xaml
    /// </summary>
    public partial class CashierDeviceValidationWindow : Window
    {
        public CashierDeviceValidationWindow(TollGate tollGate)
        {
            InitializeComponent();
            var dc = DIContainer.GetService<CashierDeviceValidationWindowViewModel>();
            dc.SetTollGate(tollGate);
            DataContext = dc;
        }
    }
}
