using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Could_System_dev_ops.Repo
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
        public IEnumerable<UsersModel> GetObject()
        {
            return _context.User;
        }

        public bool UpdateObject(UsersModel Object)
        {
            try
            {
                _context.User.Update(Object);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
