using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.SystemUsers.Users.Repository;

namespace TollStations.Core.SystemUsers.Users.Service
{
    public class AccountService : IAccountService
    {
        IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void Save()
        {
            _accountRepository.Save();
        }

        public List<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public Dictionary<int, Account> GetAllById()
        {
            return _accountRepository.GetAllById();
        }

        public Account GetById(int id)
        {
            return _accountRepository.GetById(id);
        }
    }
}
