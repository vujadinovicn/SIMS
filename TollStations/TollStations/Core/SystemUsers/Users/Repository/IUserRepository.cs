using System.Collections.Generic;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.Core.SystemUsers.Users.Repository
{
    public interface IUserRepository
    {
        List<User> Users { get; set; }
        Dictionary<int, User> UsersById { get; set; }
        Dictionary<string, User> UsersByUsername { get; set; }

        List<User> GetAll();
        Dictionary<int, User> GetAllById();
        Dictionary<string, User> GetAllByUsername();
        User GetById(int id);
        User GetByUsername(string username);
        void LoadFromFile();
        void Save();
    }
}