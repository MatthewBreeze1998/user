using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Models
{
    public class UserDataBaseContext : DbContext
    {

        public DbSet<UsersModel> User { get; set; }


        public UserDataBaseContext(DbContextOptions<UserDataBaseContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
