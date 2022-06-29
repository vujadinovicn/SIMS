using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TollStations.ViewModels.CashierViewModels;

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
            var dc = DIContainer.GetService<VehicleExitWindowViewModel>();
            dc.SetLoggedCashier(cashier);
            DataContext = dc;
        }
        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
