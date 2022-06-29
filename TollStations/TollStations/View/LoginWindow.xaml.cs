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
using TollStations.Core.Devices.Repository;
using TollStations.Core.Devices.Service;
using TollStations.Core.Locations.Repository;
using TollStations.Core.Prices.Repositor;
using TollStations.Core.RoadSections.Repository;
using TollStations.Core.SystemUsers.Cashiers.Repository;
using TollStations.Core.SystemUsers.Chiefs.Repository;
using TollStations.Core.SystemUsers.Users.Repository;
using TollStations.Core.TollCards.Repository;
using TollStations.Core.TollGates.Repository;
using TollStations.Core.TollPayments.Repository;
using TollStations.Core.TollStations.Repository;
using TollStations.View.CashierView;
using TollStations.View.ChiefView;

namespace TollStations.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
           // var tt = DIContainer.GetService<IRoadSectionRepository>();
            //lbl.Content = tt.GetAll()[0].ExitStation.Chief.FirstName;
            //var cashier = DIContainer.GetService<ICashierRepository>().GetById(1);

            //CashierInitialWindow cashierWindow = new CashierInitialWindow(cashier);
            //cashierWindow.ShowDialog();

            var chief = DIContainer.GetService<IChiefRepository>().GetById(2);
            ChiefInitialWindow chiefInitialWindow = new ChiefInitialWindow(chief);
            chiefInitialWindow.ShowDialog();
        }

        [STAThread]
        public static void Main()
        {
            var services = new DIServiceCollection();

            services.RegisterSingleton<IDeviceRepository, DeviceRepository>();
            services.RegisterSingleton<ILocationRepository, LocationRepository>();
            services.RegisterSingleton<IPriceRepository, PriceRepository>();
            services.RegisterSingleton<IRoadSectionRepository, RoadSectionRepository>();
            services.RegisterSingleton<IChiefRepository, ChiefRepository>();
            services.RegisterSingleton<ICashierRepository, CashierRepository>();
            services.RegisterSingleton<IUserRepository, UserRepository>();
            services.RegisterSingleton<ITollCardRepository, TollCardRepository>();
            services.RegisterSingleton<ITollGateRepository, TollGateRepository>();
            services.RegisterSingleton<ITollPaymentRepository, TollPaymentRepository>();
            services.RegisterSingleton<ITollStationRepository, TollStationRepository>();
            services.RegisterSingleton<IAccountRepository, AccountRepository>();

            services.RegisterSingleton<IDeviceService, DeviceService>();

            services.BuildContainer();

            DIContainer.GetService<IChiefRepository>();
            DIContainer.GetService<ITollGateRepository>();
            Window l = new LoginWindow();
            l.ShowDialog();
        }
    }
}
