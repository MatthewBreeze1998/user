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


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<UsersModel>> CreateUser(UsersModel User)
        {
            _UserRepo.CreateUser(User);

            return CreatedAtAction(nameof(getUser), new { id = User.UserId }, User);


        }
        [Route("GetUser/{id}")]
        [HttpGet]
        public ActionResult<UsersModel> getUser(int id)
        {
            UsersModel User = _UserRepo.GetUser(id);
            if (User == null)
            {
                return NotFound();
            }

            return User;
        }
        [Route("GetUserByName/{Name}")]
        [HttpGet]
        public ActionResult<UsersModel> getUserByName(String name)
        {
            UsersModel users = _UserRepo.GetUserByName(name);
            if(users == null)
            {
                return NotFound();
            }
            return users;


        }


        [Route("GetIsActive/{Active}")]
        [HttpGet]
        public IEnumerable<UsersModel> GetIsActive(Boolean Active)
        {
            return _UserRepo.GetUserIsActive(Active);
        }

    }
}