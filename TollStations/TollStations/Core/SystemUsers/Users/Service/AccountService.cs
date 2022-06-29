using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.SystemUsers.Users.Repository;

namespace TollStations.Core.SystemUsers.Users.Service
{
    public class AccountService : IAccountService
    {
        IAccountRepository _accountRepository;
        public AccountService(IAccountRepository userRepository)
        {
            _accountRepository = userRepository;
        }
        public bool IsExist(string username)
        {
            return _accountRepository.GetByUsername(username) != null;
        }

        public Account GetByUsername(String username)
        {
            return _accountRepository.GetByUsername(username);
        }

        public bool IsUserFound(Account account, string passwordInput)
        {
            if (account == null)
            {
                System.Windows.MessageBox.Show("Username doesn't exist!", "Log in error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (account.Password != passwordInput)
            {
                System.Windows.MessageBox.Show("Username and password don't match!", "Log in error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
