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
using TollStations.Core.SystemUsers.Cashiers.Model;

namespace TollStations.View.CashierView
{
    /// <summary>
    /// Interaction logic for VehicleExitWindow.xaml
    /// </summary>
    public partial class VehicleExitWindow : Window
    {
        public VehicleExitWindow(Cashier cashier)
        {
            InitializeComponent();
        }
    }
}
