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

        IEnumerable<Models.UsersModel> GetUserIsActive();
       
        IEnumerable<Models.UsersModel> GetUser(int? UserId, String FirstName, String LastName, String Email, Boolean isActive);
    
        
    }
}
