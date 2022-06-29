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
using TollStations.Core.SystemUsers.Cashiers.Service;
using TollStations.Core.TollGates.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.View.AdministratorView
{
    /// <summary>
    /// Interaction logic for AddTollGateDialog.xaml
    /// </summary>
    public partial class AddTollGateDialog : Window
    {
        public AddTollGateDialog(ITollGateService tollGateService, ICashierService cashierService)
        {
            InitializeComponent();
            DataContext = new AddTollGateDialogViewModel(tollGateService, cashierService);
        }
    }
}
