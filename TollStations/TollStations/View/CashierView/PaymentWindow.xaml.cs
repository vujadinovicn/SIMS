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
using TollStations.Core.Prices.Model;
using TollStations.Core.SystemUsers.Cashiers.Model;
using TollStations.Core.TollCards.Model;
using TollStations.ViewModels.CashierViewModels;

namespace TollStations.View.CashierView
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public PaymentWindow(Cashier cashier, TollCard tollCard, Price price)
        {
            InitializeComponent();
            rsdLabel.Content = price.PriceInRSD + " RSD";
            eurLabel.Content = price.PriceInEUR + " EUR";
            var dc = DIContainer.GetService<PaymentWindowViewModel>();
            dc.SetIncomingParameters(cashier, tollCard, price);
            DataContext = dc;
        }
        public void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
