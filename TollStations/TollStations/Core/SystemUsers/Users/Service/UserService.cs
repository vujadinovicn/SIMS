using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.SystemUsers.Users.Repository;

namespace TollStations.Core.SystemUsers.Users.Service
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Save()
        {
            _userRepository.Save();
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Dictionary<String, User> GetAllByUsername()
        {
            return _userRepository.GetAllByUsername();
        }

        public User GetByUsername(String username)
        {
            return _userRepository.GetByUsername(username);
        }

        public Dictionary<int, User> GetAllById()
        {
            return _userRepository.GetAllById();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
