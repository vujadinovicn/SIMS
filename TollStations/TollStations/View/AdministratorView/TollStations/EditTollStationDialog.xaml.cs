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
using TollStations.Core.SystemUsers.Chiefs.Service;
using TollStations.Core.TollStations.Model;
using TollStations.Core.TollStations.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.View.AdministratorView
{
    /// <summary>
    /// Interaction logic for EditTollStationDialog.xaml
    /// </summary>
    public partial class EditTollStationDialog : Window
    {
        ITollStationService _tollStationService;
        IChiefService _chiefService;
        TollStation _tollStation;

        public EditTollStationDialog(ITollStationService tollStationService, IChiefService chiefService)
        {   
            InitializeComponent();
            _chiefService = chiefService;
            _tollStationService = tollStationService;
        }

        public void SetSelectedTollStation(TollStation tollStation)
        {
            _tollStation = tollStation;
            DataContext = new EditTollStationDialogViewModel(this, tollStation, _tollStationService, _chiefService);
        }
    }
}
