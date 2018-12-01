using CodeAssgnment.Shared;
using CodeAssignment.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAssignment.Service
{
    public class UserService
    {
        private IProvider<UserEntity> _userProvider;

        public UserService()
        {
            _userProvider = new UserProvider();
        }

        public List<UserEntity> GetAllUsers()
        {
            return _userProvider.GetAll();
        }

        public UserEntity GetUser(int id)
        {
            return _userProvider.Get(id);
        }

        public int AddUpdateUser(UserEntity model)
        {
            return _userProvider.AddUpdate(model);
        }
    }
}
