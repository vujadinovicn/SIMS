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
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.View.AdministratorView.TollStations
{
    /// <summary>
    /// Interaction logic for TollStationsCashiersTable.xaml
    /// </summary>
    public partial class TollStationsCashiersTable : Window
    {
        TollStation _tollStation;
        ICashierService _cashierService;
        ITollStationService _tollStationService;
        public TollStationsCashiersTable(ITollStationService tollStationService, ICashierService cashierService)
        {
            InitializeComponent();
            _cashierService = cashierService;
            _tollStationService = tollStationService;
        }

        public void SetTollStation(TollStation tollStation)
        {
            _tollStation = tollStation;
            DataContext = new TollStationsCashiersTableViewModel(_tollStation, _tollStationService, _cashierService);
        }
    }
}
