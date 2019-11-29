using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Models
{
    public class ManagementPermissionsModel
    {
        public int StaffId { get; set; }
        
        public Boolean AddStaff{ get; set; }

        public Boolean RemoveStaff { get; set; }

        public Boolean authorisePermissons{ get; set; }

        public Boolean ApproveStaffPurchase { get; set; }
    }
}
