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
        [Route("CreateUser")]// create user route 
        [HttpPost]
        public ActionResult<UsersModel> CreateUser(UsersModel User)
        {
            if(User == null)
            {
                return BadRequest();
            }

            int newId = _UserRepo.GetUsers().Max(x => x.UserId + 1);// gats max id and adds one
            User.UserId = newId; // sets new id


            _UserRepo.CreateUser(User);// calls the function to create a new User
            return CreatedAtAction(nameof(GetUser), new { id = User.UserId }, User); // create at action creats a new user 
        }
        [Route("DeleteUser/")]
        public ActionResult<UsersModel> DeleteUser(UsersModel User)
        {
            if(User == null)
            {
                return BadRequest();
            }// checks user is not null
            return _UserRepo.DeleteUser(User); // calls delete fumction
        }

        [Route("EditUser")] // edit User route
        [HttpPost]
        public ActionResult<UsersModel> EditUser(UsersModel User)
        {
            if (User == null)
            {
                return BadRequest();
            }// checks if there is a valid User
            return _UserRepo.EditUser(User);// calls edit user and returns edit user
        }

        [Route("GetAllUsers")] // get all users route
        [HttpGet]
        public IEnumerable<UsersModel> GetAllUsers()
        { 
             
            return _UserRepo.GetUsers(); // retruns all users as a list
        }

        [Route("GetUser/{id}")]// user by id route
        [HttpGet]
        public ActionResult<UsersModel> GetUser(int? id)
        {
            if (id == null)
            { 
                return BadRequest();
            }// checks if is a valid id     
          
            UsersModel User = _UserRepo.GetUser(id);// checks for user
            return User; // retunrs users model
        }


        [Route("GetIsActive/{id}")]// get active by id route
        [HttpGet]
        public bool GetIsActive(int id)
        {
            UsersModel UserActive = _UserRepo.GetUser(id); //gets user by id 
            return UserActive.isActive;// returns is active paramiter
        }

        [Route("ToggleIsActive")]// toggle active route
        [HttpPost]
        public ActionResult<UsersModel> ToggleActivity(UsersModel user)
        {
        
            if(user == null)
            {
                return BadRequest();
            }// checks valid user
            user.isActive = !user.isActive;// toggles is active
            UsersModel activity = _UserRepo.EditUser(user);// creates new user model and passes through user
            return activity;// return the edited user


        }
           

    }
}