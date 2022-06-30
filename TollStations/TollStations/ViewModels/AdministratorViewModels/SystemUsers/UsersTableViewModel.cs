using HealthInstitution.Core.DIContainer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TollStations.Core.SystemUsers.Users.Model;
using TollStations.Core.SystemUsers.Users.Repository;
using TollStations.Core.SystemUsers.Users.Service;
using TollStations.ViewModels.ModelViewModels;

namespace TollStations.ViewModels.AdministratorViewModels
{
    public class UsersTableViewModel : ViewModelBase
    {
        IUserService _userService;
        public List<User> Users;

        private ObservableCollection<UserViewModel> _usersVM;

        public ObservableCollection<UserViewModel> UsersVM
        {
            get
            {
                return _usersVM;
            }
            set
            {
                _usersVM = value;
                OnPropertyChanged(nameof(UsersVM));
            }
        }

        public void RefreshGrid()
        {
            _usersVM.Clear();
            Users.Clear();
            foreach (User user in _userService.GetAll())
            {
                Users.Add(user);
                _usersVM.Add(new UserViewModel(user));
            }
        }

        public UsersTableViewModel(IUserService userService)
        {
            _userService = userService;
            Users = new();
            _usersVM = new();
            RefreshGrid();
        }
    }
}
