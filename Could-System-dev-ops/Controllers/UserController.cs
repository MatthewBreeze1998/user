using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using Microsoft.AspNetCore.Authorization;
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
                return BadRequest();
            }

            _UserRepo.EditUser(User);
            return CreatedAtAction(nameof(GetUser), new { id = User.UserId }, User);
        }
      
        [Route("CreateUser")]
        [HttpPost]
        public ActionResult<UsersModel> CreateUser(UsersModel User)
        {
            if(User == null)
            {
                return BadRequest();
            }
            _UserRepo.CreateUser(User);
            return CreatedAtAction(nameof(GetUser), new { id = User.UserId }, User);
        }
       
        [Route("GetAllUsers")]
        [HttpGet]
        public IEnumerable<UsersModel> GetAllUsers()
        { 
             
            return _UserRepo.GetUsers();
        }

        [Route("GetUser/{id}")]
        [HttpGet]
        public ActionResult<UsersModel> GetUser(int? id)
        {
            if (id == null)
            { 
                return BadRequest();
            }     
          
            UsersModel User = _UserRepo.GetUser(id);
            return CreatedAtAction(nameof(GetUser), new { id = User.UserId }, User);
        }


        [Route("GetIsActive/{id}")]
        [HttpGet]
        public bool GetIsActive(int id)
        {
            UsersModel UserActive = _UserRepo.GetUser(id);
            return UserActive.isActive;
        }

        [Route("ToggleIsActive")]
        [HttpPost]
        public ActionResult<UsersModel> ToggleActivity(UsersModel user)
        {
        
            if(user == null)
            {
                return BadRequest();
            }
            if(user.UserId < 1 )
            {
                return BadRequest();
            }
            user.isActive = !user.isActive;
            UsersModel activity = _UserRepo.EditUser(user);
            return activity;


        }
           

    }
}