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
using TollStations.Core.Reports;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels;

namespace TollStations.View.ManagerView
{
    /// <summary>
    /// Interaction logic for EarningsByVehicleTypeWindow.xaml
    /// </summary>
    public partial class EarningsByVehicleTypeWindow : Window
    {
        public EarningsByVehicleTypeWindow(IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService, TollStation station)
        {
            InitializeComponent();
            DataContext = new EarningsTableViewModel(reportService, tollStationService, station);
        }
    }
}
