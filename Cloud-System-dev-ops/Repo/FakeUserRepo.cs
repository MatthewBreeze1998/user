using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;

namespace Cloud_System_dev_ops.Repo
{
    public class FakeUserRepo : IRepository<UsersModel>

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


        public UsersModel CreateObject(UsersModel Users)
        {
            Users.UserId = GetNextId();

            _UserModelList.Add(Users);
            return Users;
        }

        public IEnumerable<UsersModel> GetObjects()
        {
            return _UserModelList.AsEnumerable<UsersModel>();
        }

        public UsersModel UpdateObject(UsersModel User)
        {
            UsersModel inMemoryModel = _UserModelList.FirstOrDefault(x => x.UserId == User.UserId);

            if(inMemoryModel == null)
            {
                return null;
            }

            try
            {
                int index = _UserModelList.IndexOf(inMemoryModel);
                _UserModelList[index] = User;

                return User;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public UsersModel DeleteObject(UsersModel User)
        {
            _UserModelList.Remove(_UserModelList.FirstOrDefault(x => x.UserId == User.UserId));
            return User;
        }

        private int GetNextId()
        {
            return (_UserModelList == null || _UserModelList.Count() == 0) ? 1 : _UserModelList.Max(x => x.UserId) + 1;
        }
    }
}
