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
using TollStations.Core.TollGates;
using TollStations.Core.TollGates.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.View.AdministratorView
{
    /// <summary>
    /// Interaction logic for EditTollGateDialog.xaml
    /// </summary>
    public partial class EditTollGateDialog : Window
    {
        ITollGateService _tollGateService; 
        ICashierService _cashierService;
        public EditTollGateDialog(ITollGateService tollGateService, ICashierService cashierService)
        {
            _tollGateService = tollGateService;
            _cashierService = cashierService;
            InitializeComponent();
        }

        public void SetSelectedTollGate(TollGate tollGate)
        {
            DataContext = new EditTollGateDialogViewModel(tollGate, _tollGateService, _cashierService);
        }
    }
}
