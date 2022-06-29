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
using TollStations.Core.Prices;
using TollStations.ViewModels.ManagerViewModels;

namespace TollStations.View.ManagerView
{
    /// <summary>
    /// Interaction logic for PricelistWindow.xaml
    /// </summary>
    public partial class PricelistWindow : Window
    {
        public PricelistWindow()
        {
            InitializeComponent();
            DataContext = DIContainer.GetService<PricelistWindowViewModel>();
        }
    }
}
