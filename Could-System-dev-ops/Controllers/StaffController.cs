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
    [Route("api/Staff")]
    public class StaffController : Controller
    {

        private StaffRepo _StaffRepo;
        public StaffController(StaffRepo staff)
        {
            _StaffRepo = staff;
        }
        [HttpPost]
        public async Task<ActionResult<StaffModel>> CreateStaff(StaffModel staff)
        {
            _StaffRepo.CreateStaff(staff);

            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);


        }
        [Route("GetAllStaff")]
        [HttpGet]
        public IEnumerable<StaffModel> GetAllStaff()
        {
           return _StaffRepo.GetStaffAll();
        }

        [Route("GetStaff/{id}")]
        [HttpGet]
        public ActionResult<StaffModel> GetStaff(int id)
        {
            StaffModel createstaff = _StaffRepo.GetStaff(id);

            if (createstaff == null)
            {
                return NotFound();
            }
            return createstaff;
        }
        [Route("StaffPermissions/{id}")]
        [HttpPost]
        public ActionResult<StaffPermissonsModel> GetPermissons(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            _StaffRepo.GetStaffPermissions(id);
            StaffPermissonsModel staffPermissons = _StaffRepo.GetStaffPermissions(id);
            return staffPermissons;
        }
        [Route("purchaseAbility/{id}")]
        [HttpPost]
        public async Task<ActionResult<UsersModel>> SetPurchaseAbilty(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            UsersModel User = _StaffRepo.SetPurchaseAbility(id);
            return User;
        }
        [Route("DeleteStaff/{id}")]
        [HttpPost]
        public async Task<ActionResult<StaffModel>> DeleteStaff(int id)
        {
            if (id == 0)
            {
                return NotFound();

            }
            StaffModel user = _StaffRepo.DeleteStaff(id);
            return user;
        }
        [Route("editstaff/{id}")]
        [HttpPost]
        public async Task<ActionResult<StaffModel>> EditStaff(StaffModel User)
        {
            if (User == null)
            {
                return NotFound();
            }
            StaffModel Useredit = _StaffRepo.EditStaff(User);
            return Useredit;
        }
        

    }
}