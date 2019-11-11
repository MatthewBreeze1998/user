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
    public class StaffController : Controller
    {



        private StaffRepo _StaffRepo;
        public StaffController(StaffRepo staff)
        {
            _StaffRepo = staff;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        public async Task<ActionResult<StaffModel>> CreateStaff(StaffModel staff)
        {
            _StaffRepo.CreateStaff(staff);

            return CreatedAtAction(nameof(GetStaff), new { id })

        }
       
    }
}