using System.Collections.Generic;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.Core.SystemUsers.Users.Repository
{
    public interface IAccountRepository
    {
        List<Account> Accounts { get; set; }
        Dictionary<int, Account> AccountsById { get; set; }

        List<Account> GetAll();
        Dictionary<int, Account> GetAllById();
        Account GetById(int id);
        void LoadFromFile();
        void Save();
    }
}