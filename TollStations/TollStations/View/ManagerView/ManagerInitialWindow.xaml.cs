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
using TollStations.ViewModels.ManagerViewModels;

namespace TollStations.View.ManagerView
{
    /// <summary>
    /// Interaction logic for ManagerInitialWindow.xaml
    /// </summary>
    public partial class ManagerInitialWindow : Window
    {
        public ManagerInitialWindow(IEarningsByVehicleTypeReportService reportService, ITollStationService tollStationService)
        {
            InitializeComponent();
            DataContext = new ManagerInitialWindowViewModel(reportService, tollStationService);
        }
    }
}
