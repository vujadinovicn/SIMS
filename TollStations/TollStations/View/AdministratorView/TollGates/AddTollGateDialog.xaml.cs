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
using TollStations.Core.TollStations.Model;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.View.AdministratorView
{
    /// <summary>
    /// Interaction logic for AddTollGateDialog.xaml
    /// </summary>
    public partial class AddTollGateDialog : Window
    {
        TollStation _tollStation;
        ITollGateService _tollGateService;
        ICashierService _cashierService;
        public AddTollGateDialog(ITollGateService tollGateService, ICashierService cashierService)
        {
            InitializeComponent();
            _tollGateService = tollGateService;
            _cashierService = cashierService;
        }

        public void SetSelectedTollStation(TollStation tollStation)
        {
            _tollStation = tollStation;
            DataContext = new AddTollGateDialogViewModel(this, tollStation, _tollGateService, _cashierService);
        }
    }
}
