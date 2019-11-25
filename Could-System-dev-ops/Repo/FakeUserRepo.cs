using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeUserRepo : UserRepo

    {

        private List<UsersModel> _UserList;

        public FakeUserRepo()
        {
            _UserList = new List<UsersModel>()
            {
                new UsersModel() {UserId = 1,FirstName = "cameron", lastName = "charlton",Email = "charlton98@gmail.com", isActive = true },
                new UsersModel() {UserId = 1,FirstName = "Shaun", lastName = "andrew",Email = "shaun_andrew@hotmail.com",isActive = false  },
                new UsersModel() {UserId = 1,FirstName = "danielle", lastName = "houston",Email = "Danielle@outlook.com",isActive = true }
            };
        }


        public UsersModel CreateUser(UsersModel users)
        {
            _UserList.Add(users);
            return users;
        }

        
        public UsersModel GetUser(int id)
        {
            return _UserList.FirstOrDefault(x => id == x.UserId);
        }

        public IEnumerable<UsersModel> GetUser(int? UserId, String FirstName, String LastName, String Email,Boolean isActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsersModel> GetUserIsActive()
        {
            return _UserList.Where(x => x.isActive);
        }
    }
}
