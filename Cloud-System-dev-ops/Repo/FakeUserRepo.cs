using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;

namespace Cloud_System_dev_ops.Repo
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

        public UsersModel DeleteUser(UsersModel User)
        {
            _UserModelList.Remove(_UserModelList.FirstOrDefault(x => x.UserId == User.UserId));
            return User;
        }

        public UsersModel GetUser(int? id)
        {
         
            UsersModel User = _UserModelList.FirstOrDefault(x => id == x.UserId);

            return User;
        
        }

        public IEnumerable<UsersModel> GetUsers()
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
