using Microsoft.EntityFrameworkCore;
using OnlineService.Data;
using OnlineService.Interfaces;
using OnlineService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineService.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User GetById(uint id)
        {
            var byIdUser = _context.Users
                .Include(u => u.Orders)
                .FirstOrDefault(u => u.Id == id);

            return byIdUser;
        }

        public IEnumerable<Order> GetByUser(uint userId)
        {
            var byUserOrder = _context.Orders
                .Include(o => o.Service)
                .Include(o => o.User)
                .Include(o => o.Specialist)
                .Where(o => o.UserId == userId)
                .ToList();

            return byUserOrder;
        }

        public IEnumerable<User> GetAll()
        {
            var allUser = _context.Users
                .Include(u => u.Orders)
                .ToList();

            return allUser;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(uint id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
