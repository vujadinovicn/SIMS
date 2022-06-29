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
using TollStations.Core.SystemUsers.Chiefs.Model;
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
            DataContext = new ChiefInitialWindowViewModel(chief);
        }
    }
}
