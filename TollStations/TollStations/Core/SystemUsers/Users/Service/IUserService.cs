using System.Collections.Generic;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.Core.SystemUsers.Users.Service
{
    public interface IUserService
    {
        List<User> GetAll();
        Dictionary<int, User> GetAllById();
        Dictionary<string, User> GetAllByUsername();
        User GetById(int id);
        User GetByUsername(string username);
        void Save();
    }
}