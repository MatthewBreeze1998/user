using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface UserRepo

    {
        UsersModel CreateUser(Models.UsersModel User);

        UsersModel GetUser(int id);

        UsersModel GetUserByName(String Name);

        UsersModel EditUser(UsersModel User);

        UsersModel SetActivity(int id);

        IEnumerable<Models.UsersModel> GetUserIsActive(Boolean Active);
       
        IEnumerable<Models.UsersModel> GetUser(int? UserId, string FirstName, string LastName, string Email, Boolean? isActive);
    

    }
}
