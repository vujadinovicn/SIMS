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
using TollStations.Core.SystemUsers.Users.Service;
using TollStations.ViewModels.AdministratorViewModels;

namespace TollStations.View.AdministratorView
{
    /// <summary>
    /// Interaction logic for AccountTable.xaml
    /// </summary>
    public partial class AccountsTable : Window
    {
        public AccountsTable(IAccountService accountService)
        {
            InitializeComponent();
            DataContext = new AccountsTableViewModel(accountService);
        }
    }
}
