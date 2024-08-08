using Microsoft.EntityFrameworkCore;
using OnlineService.Data;
using OnlineService.Interfaces;
using OnlineService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineService.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Order GetById(uint id)
        {
            var byIdOrder = _context.Orders
                .Include(o => o.Service)
                .Include(o => o.User)
                .Include(o => o.Specialist)
                .FirstOrDefault(o => o.Id == id);

            return byIdOrder;
        }

        public IEnumerable<Order> GetAll()
        {
            var allOrder = _context.Orders
                .Include(o => o.Service)
                .Include(o => o.User)
                .Include(o => o.Specialist)
                .ToList();

            return allOrder;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(uint id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}

