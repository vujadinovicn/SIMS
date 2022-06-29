using HealthInstitution.Core.DIContainer;
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
using TollStations.Core.SystemUsers.Chiefs.Model;
using TollStations.Core.TollStations;
using TollStations.ViewModels.ChiefViewModels;

namespace TollStations.View.ChiefView
{
    /// <summary>
    /// Interaction logic for ChiefInitialWindow.xaml
    /// </summary>
    public partial class ChiefInitialWindow : Window
    {
        public ChiefInitialWindow(Chief chief)
        {
            InitializeComponent();
            var dc = DIContainer.GetService<ChiefInitialWindowViewModel>();
            dc.SetChief(chief);
            DataContext = dc;
        }
    }
}
