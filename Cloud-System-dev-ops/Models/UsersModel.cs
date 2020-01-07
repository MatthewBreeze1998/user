using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Models
{
    public class UsersModel
    {
        [Key]
        public int UserId{ get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public bool isActive { get; set; }
        public bool PurchaseAbility { get; set; }
    }
}
