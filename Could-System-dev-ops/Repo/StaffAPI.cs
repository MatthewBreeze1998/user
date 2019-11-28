using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface StaffRepo

    {
        StaffModel DeleteStaff(int id);

        StaffModel CreateStaff(Models.StaffModel staff);

        StaffModel GetStaff(int id);

        IEnumerable<Models.StaffModel> GetStaff(int? StaffId, String FirstName, String LastName, String Email, double? ContactNumebr, double? PayRoll);


    }
}
