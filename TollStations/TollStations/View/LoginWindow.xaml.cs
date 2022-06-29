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
using TollStations.Core.Prices;
using TollStations.Core.Prices.Repositor;
using TollStations.Core.Reports;
using TollStations.Core.RoadSections.Repository;
using TollStations.Core.SystemUsers.Cashiers.Repository;
using TollStations.Core.SystemUsers.Chiefs.Repository;
using TollStations.Core.SystemUsers.Users.Repository;
using TollStations.Core.TollCards;
using TollStations.Core.TollCards.Repository;
using TollStations.Core.TollGates.Repository;
using TollStations.Core.TollPayments;
using TollStations.Core.TollPayments.Repository;
using TollStations.Core.TollStations;
using TollStations.Core.TollStations.Repository;
using TollStations.View.CashierView;
using TollStations.View.ManagerView;
using TollStations.ViewModels;
using TollStations.ViewModels.CashierViewModels;
using TollStations.ViewModels.ManagerViewModels;
using TollStations.View.ChiefView;
using TollStations.ViewModels.ChiefViewModels;
using TollStations.Core.SystemUsers.Users.Service;

namespace TollStations.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static double euroExchangeRate = 117.98;
        private String _usernameInput;
        private String _passwordInput;

        private IAccountService _accountService;
        public LoginWindow(IAccountService accountService)
        {
            InitializeComponent();
            this.DataContext = new LoginWindowViewModel(this, accountService);

            _accountService = accountService;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).SecurePassword;
            }
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
            services.RegisterSingleton<ITollCardService, TollCardService>();
            services.RegisterSingleton<IPriceService, PriceService>();
            services.RegisterSingleton<ITollPaymentService, TollPaymentService>();
            services.RegisterSingleton<IEarningsByVehicleTypeReportService, EarningsByVehicleTypeReportService>();
            services.RegisterSingleton<IMostVisitedStationsReportService, MostVisitedStationsReportService>();
            services.RegisterSingleton<ITollStationService, TollStationService>();
            services.RegisterSingleton<IDeviceService, DeviceService>();
            services.RegisterSingleton<IAccountService, AccountService>();

            services.RegisterTransient<LoginWindowViewModel>();
            services.RegisterTransient<CashierInitialWindowViewModel>();
            services.RegisterTransient<VehicleExitWindowViewModel>();
            services.RegisterTransient<PaymentWindowViewModel>();
            services.RegisterTransient<EarningsTableViewModel>();
            services.RegisterTransient<ManagerInitialWindowViewModel>();
            services.RegisterTransient<MostVisitedStationsWindowViewModel>();
            services.RegisterTransient<PricelistWindowViewModel>();
            services.RegisterTransient<CashierDeviceValidationWindowViewModel>();
            services.RegisterTransient<ChiefInitialWindowViewModel>();
            services.RegisterTransient<DeviceValidationWindowViewModel>();
            services.RegisterTransient<LoginWindow>();
            services.BuildContainer();

            DIContainer.GetService<IAccountRepository>();
            DIContainer.GetService<IUserRepository>();
            
            DIContainer.GetService<IChiefRepository>();
            DIContainer.GetService<ITollGateRepository>();
            DIContainer.GetService<ITollPaymentRepository>();
            

            var loginWindow = DIContainer.GetService<LoginWindow>();
            loginWindow.ShowDialog();
        }
    }
}
