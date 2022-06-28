using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.Core.SystemUsers.Users.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private int _maxId;
        private String _fileName = @"..\..\..\Data\accounts.json";
        public List<Account> Accounts { get; set; }
        public Dictionary<int, Account> AccountsById { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public AccountRepository()
        {
            this.Accounts = new List<Account>();
            this.AccountsById = new Dictionary<int, Account>();
            this._maxId = 0;
            this.LoadFromFile();
        }

        private Account Parse(JToken? account)
        {
            UserType userType;
            Enum.TryParse<UserType>((string)account["userType"], out userType);
            return new Account((int)account["id"],
                                      (string)account["username"],
                                      (string)account["password"],
                                      userType,
                                      null);
        }

        public void LoadFromFile()
        {
            var accounts = JArray.Parse(File.ReadAllText(_fileName));
            foreach (var account in accounts)
            {
                Account loadedAccount = Parse(account);
                if (loadedAccount.Id > _maxId)
                {
                    _maxId = loadedAccount.Id;
                }
                this.Accounts.Add(loadedAccount);
                this.AccountsById[loadedAccount.Id] = loadedAccount;
            }
        }

        private List<dynamic> PrepareForSerialization()
        {
            List<dynamic> reducedAccounts = new List<dynamic>();
            foreach (var account in Accounts)
            {
                reducedAccounts.Add(new
                {
                    id = account.Id,
                    username = account.Username,
                    password = account.Password,
                    userType = account.UserType
                });
            }
            return reducedAccounts;
        }

        public void Save()
        {
            var allUsers = JsonSerializer.Serialize(PrepareForSerialization(), _options);
            File.WriteAllText(this._fileName, allUsers);
        }

        public List<Account> GetAll()
        {
            return this.Accounts;
        }

        public Dictionary<int, Account> GetAllById()
        {
            return AccountsById;
        }

        public Account GetById(int id)
        {
            if (this.AccountsById.ContainsKey(id))
                return this.AccountsById[id]; ;
            return null;
        }

    }
}
