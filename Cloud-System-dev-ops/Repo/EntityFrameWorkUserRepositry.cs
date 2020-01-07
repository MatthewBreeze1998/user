using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Cloud_System_dev_ops.Repo
{
    public class EntityFrameWorkUserRepositry : IRepository<UsersModel>
    {
        private readonly IServiceScope _scope;
        private readonly UserDataBaseContext _context;

        public EntityFrameWorkUserRepositry(IServiceProvider service)
        {
            _scope = service.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<UserDataBaseContext>();

        }
        public UsersModel CreateObject(UsersModel Object)
        {
            _context.User.Add(Object);
            _context.SaveChanges();

            return Object;
        }

        public UsersModel DeleteObject(UsersModel Object)
        {
            try
            {
                _context.User.Remove(Object);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return Object;
            }

            return null;
        }

        public IEnumerable<UsersModel> GetObjects()
        {
            return _context.User;
        }

        public UsersModel UpdateObject(UsersModel Object)
        {
            try
            {
                _context.User.Update(Object);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return Object;
        }
    }
}
