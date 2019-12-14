using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeUserRepo : UserRepo

    {

        private List<UsersModel> _UserModelList;

        public FakeUserRepo()
        {
            _UserModelList = new List<UsersModel>()
            {
                new UsersModel() {UserId = 1,FirstName = "cameron", LastName = "charlton",Email = "charlton98@gmail.com", isActive = true, PurchaseAbility = true },
                new UsersModel() {UserId = 2,FirstName = "Shaun", LastName = "andrew",Email = "shaun_andrew@hotmail.com",isActive = false,  PurchaseAbility = false },
                new UsersModel() {UserId = 3,FirstName = "danielle", LastName = "houston",Email = "Danielle@outlook.com",isActive = true,  PurchaseAbility = false}
            };
        }


        public UsersModel CreateUser(UsersModel Users)
        {
            _UserModelList.Add(Users);
            return Users;
        }

        public UsersModel GetUser(int? id)
        {
         
            return _UserModelList.FirstOrDefault(x => id == x.UserId);
        
        }

        public IEnumerable<UsersModel> GetUsers(UsersModel User)
        {
            return _UserModelList.AsEnumerable<UsersModel>();
        }

        public UsersModel EditUser(UsersModel User)
        {
           
            _UserModelList[_UserModelList.IndexOf(_UserModelList.FirstOrDefault(x => x.UserId == User.UserId))] = User;
            return User;
        }
    }
}
