using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeUserRepo : UserRepo

    {

        private List<UsersModel> _ReviewlList;

        public FakeUserRepo()
        {
            _ReviewlList = new List<UsersModel>()
            {
                new UsersModel() {UserId = 1,FirstName = "cameron", lastName = "charlton",Email = "charlton98@gmail.com", },
                new UsersModel() {UserId = 1,FirstName = "Shaun", lastName = "andrew",Email = "shaun_andrew@hotmail.com", },
                new UsersModel() {UserId = 1,FirstName = "danielle", lastName = "houston",Email = "Danielle@outlook.com",}
            };
        }


        public UsersModel CreateUser(UsersModel users)
        {
            _ReviewlList.Add(users);
            return users;
        }

        public UsersModel GetUser(int id)
        {
            return _ReviewlList.FirstOrDefault(x => id == x.UserId);
        }

        public IEnumerable<UsersModel> GetUser(int? UserId, String FirstName, String LastName, String Email)
        {
            throw new NotImplementedException();
        }
    }
}
