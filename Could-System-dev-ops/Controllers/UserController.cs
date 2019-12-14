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
    [ApiController]
    public class UserController : Controller
    {

        private UserRepo _UserRepo;
        public UserController(UserRepo User)
        {
            _UserRepo = User;
        }

        [Route("EditUser")]
        [HttpPost]
        public ActionResult<UsersModel> EditUser(UsersModel User)
        {
            if (User == null)
            {
                return NotFound();
            }

            _UserRepo.EditUser(User);
            return User;
        }
      
        [Route("CreateUser")]
        [HttpPost]
        public ActionResult<UsersModel> CreateUser(UsersModel User)
        {
            if (User == null)
            {
                return NotFound();
            }
            _UserRepo.CreateUser(User);
            return User;
        }
       
        [Route("GetAllUsers")]
        [HttpGet]
        public IEnumerable<UsersModel> GetAllStaff(UsersModel users)
        { 
            IEnumerable<UsersModel> All = _UserRepo.GetUsers(users);
            return All;
        }

        [Route("GetUser/{id}")]
        [HttpGet]
        public ActionResult<UsersModel> getUser(int id)
        {
            if (id <= 0)
            { 
                return NotFound();
            }
           /* if(name == "")
            {
                return NotFound();
            }*/
            
            UsersModel User = _UserRepo.GetUser(id);
            return User;
        }


        [Route("GetIsActive/{id}")]
        [HttpGet]
        public bool GetIsActive(int id)
        {
            UsersModel UserActive = _UserRepo.GetUser(id);
            return UserActive.isActive;
        }

        [Route("SetIsActive")]
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