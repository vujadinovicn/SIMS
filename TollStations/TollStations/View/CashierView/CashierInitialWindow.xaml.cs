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
using TollStations.ViewModels.CashierViewModels;

namespace TollStations.View.CashierView
{
    /// <summary>
    /// Interaction logic for CashierInitialWindow.xaml
    /// </summary>
    public partial class CashierInitialWindow : Window
    {
        public CashierInitialWindow(Cashier cashier)
        {
            InitializeComponent();
            DataContext = new CashierInitialWindowViewModel(cashier);
        }
    }
}
