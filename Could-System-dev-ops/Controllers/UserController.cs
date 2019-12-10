using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Could_System_dev_ops.Controllers
{
    [Route("api/User")]
    public class UserController : Controller
    {

       

        private UserRepo _UserRepo;
        public UserController(UserRepo User)
        {
            _UserRepo = User;
        }


        [Route("CreateUser/{User}")]
        [HttpPost]
        public ActionResult<UsersModel> CreateUser(UsersModel User)
        {
            
            if(User == null)
            {
                return NotFound();
            }
            CreatedAtAction(nameof(getUser), new { id = User.UserId }, User);
            _UserRepo.CreateUser(User);
            return User;


        }


        [Route("GetUser/{id,name}")]
        [HttpGet]
        public ActionResult<UsersModel> getUser(int id, string name)
        {
            if (id <= 0)
            { 
                return NotFound();
            }
            if(name == "")
            {
                return NotFound();
            }
            
            UsersModel User = _UserRepo.GetUser(id,name);
            return User;
        }


        [Route("GetIsActive/{Active}")]
        [HttpGet]
        public bool GetIsActive(UsersModel users)
        {
            UsersModel UserActive = _UserRepo.GetUser(users.UserId, users.FirstName);


            return UserActive.isActive;
        }

        [Route("SetIsActive/{user}")]
        [HttpPost]
        public ActionResult<UsersModel> SetActivity(UsersModel user)
        {
        
            if(user == null)
            {
                return NotFound();
            }
            if(user.UserId < 1 )
            {
                return NotFound();
            }
            user.isActive = !user.isActive;
            UsersModel activity = _UserRepo.EditUser(user);
            return activity;


        }
           

    }
}