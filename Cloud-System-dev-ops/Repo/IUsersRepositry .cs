using Cloud_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Repo
{
    public interface UserRepo
    {
        IEnumerable<UsersModel> GetUsers();
        UsersModel CreateUser(UsersModel User);
        UsersModel GetUser(int? id);
        UsersModel EditUser(UsersModel User);
        UsersModel DeleteUser(UsersModel User);
    }
}
