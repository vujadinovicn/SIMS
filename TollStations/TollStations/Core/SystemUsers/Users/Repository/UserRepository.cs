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
    public class UserRepository : IUserRepository
    {
        private int _maxId;
        private String _fileName = @"..\..\Data\users.json";
        public List<User> Users { get; set; }
        public Dictionary<int, User> UsersById { get; set; }
        public Dictionary<String, User> UsersByUsername { get; set; }

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            PropertyNameCaseInsensitive = true
        };

        public UserRepository()
        {
            this.Users = new List<User>();
            this.UsersByUsername = new Dictionary<String, User>();
            this.UsersById = new Dictionary<int, User>();
            this.LoadFromFile();
        }

        private User Parse(JToken? user)
        {
            return new User((int)user["id"],
                                      (string)user["firstName"],
                                      (string)user["lastName"],
                                      (int)user["tel"],
                                      (string)user["mail"],
                                      (string)user["address"],
                                      null,
                                      null);
        }

        public void LoadFromFile()
        {
            var users = JArray.Parse(File.ReadAllText(_fileName));
            foreach (var user in users)
            {
                User loadedUser = Parse(user);
                if (loadedUser.Id > _maxId)
                {
                    _maxId = loadedUser.Id;
                }
                this.Users.Add(loadedUser);
                this.UsersByUsername[loadedUser.Account.Username] = loadedUser;
                this.UsersById[loadedUser.Id] = loadedUser;
            }
        }

        private List<dynamic> PrepareForSerialization()
        {
            List<dynamic> reducedUsers = new List<dynamic>();
            foreach (var user in Users)
            {
                reducedUsers.Add(new
                {
                    id = user.Id,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    tel = user.Tel,
                    mail = user.Mail,
                    address = user.Address,
                    location = user.Location.Id,
                    account = user.Account.Id
                }) ;
            }
            return reducedUsers;
        }

        public void Save()
        {
            var allUsers = JsonSerializer.Serialize(PrepareForSerialization(), _options);
            File.WriteAllText(this._fileName, allUsers);
        }

        public List<User> GetAll()
        {
            return this.Users;
        }

        public Dictionary<String, User> GetAllByUsername()
        {
            return UsersByUsername;
        }

        public User GetByUsername(String username)
        {
            if (this.UsersByUsername.ContainsKey(username))
                return this.UsersByUsername[username]; ;
            return null;
        }

        public Dictionary<int, User> GetAllById()
        {
            return UsersById;
        }

        public User GetById(int id)
        {
            if (this.UsersById.ContainsKey(id))
                return this.UsersById[id]; ;
            return null;
        }
    }
}
