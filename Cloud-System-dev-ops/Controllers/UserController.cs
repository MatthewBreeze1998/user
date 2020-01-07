using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;
using Cloud_System_dev_ops.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cloud_System_dev_ops.Controllers
{
    [Route("api/User")]
    [ApiController]
 
    public class UserController : Controller
    {

        private IRepository<UsersModel> _UserRepo;
        public UserController(IRepository<UsersModel> User)
        {
            _UserRepo = User;
        }
        [Authorize(Policy = "Staffpol")]
        [Route("CreateUser")]// create user route 
        [HttpPost]
        public ActionResult<UsersModel> CreateUser(UsersModel User)
        {
            if(User == null)
            {
                return BadRequest();
            }

            _UserRepo.CreateObject(User);// calls the function to create a new User
            return CreatedAtAction(nameof(GetUser), new { id = User.UserId }, User); // create at action creats a new user 
        }
        [Authorize(Policy = "Staffpol")]
        [Route("DeleteUser/")]
        [HttpPost]
        public ActionResult<UsersModel> DeleteUser(UsersModel User)
        {
            if(User == null)
            {
                return BadRequest();
            }// checks user is not null
            return _UserRepo.DeleteObject(User); // calls delete fumction
        }
        [Authorize]
        [Route("EditUser")] // edit User route
        [HttpPost]
        public ActionResult<UsersModel> EditUser(UsersModel User)
        {
            if (User == null)
            {
                return BadRequest();
            }// checks if there is a valid User
            return _UserRepo.UpdateObject(User);// calls edit user and returns edit user
        }
        [Authorize]
        [Route("GetAllUsers")] // get all users route
        [HttpGet]
        public IEnumerable<UsersModel> GetAllUsers()
        { 
             
            return _UserRepo.GetObjects(); // retruns all users as a list
        }
        [Authorize]
        [Route("GetUser/{id}")]// user by id route
        [HttpGet]
        public ActionResult<UsersModel> GetUser(int? id)
        {
            if (id == null)
            { 
                return BadRequest();
            }// checks if is a valid id     
          
            UsersModel User = _UserRepo.GetObjects().FirstOrDefault(x => x.UserId == id);// checks for user
            return User; // retunrs users model
        }

        [Authorize(Policy = "Staffpol")]
        [Route("GetIsActive/{id}")]// get active by id route
        [HttpGet]
        public bool GetIsActive(int id)
        {
            UsersModel UserActive = _UserRepo.GetObjects().FirstOrDefault(x => x.UserId == id); //gets user by id 
            return UserActive.isActive;// returns is active paramiter
        }
        [Authorize(Policy = "Staffpol")]
        [Route("ToggleIsActive")]// toggle active route
        [HttpPost]
        public ActionResult<UsersModel> ToggleActivity(UsersModel user)
        {
            if(user == null)
            {
                return BadRequest();
            }// checks valid user
            user.isActive = !user.isActive;// toggles is active
            UsersModel activity = _UserRepo.UpdateObject(user);// creates new user model and passes through user
            return activity;// return the edited user
        }
    }
}