using Microsoft.EntityFrameworkCore;
using OnlineService.Data;
using OnlineService.Interfaces;
using OnlineService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineService.Repositories
{
    public class ServiceRepository : IService
    {
        private readonly ApplicationContext _context;

        public ServiceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Service GetById(uint id)
        {
            var byIdService = _context.Services
                .Include(s => s.Categoria)
                .Include(s => s.Specialists)
                .Include(s => s.Orders)
                .FirstOrDefault(s => s.Id == id);

            return byIdService;
        }

        public IEnumerable<Service> GetAll()
        {
            var allService = _context.Services
                .Include(s => s.Categoria)
                .Include(s => s.Specialists)
                .Include(s => s.Orders)
                .ToList();

            return allService;
        }

        public IEnumerable<Service> GetByCategory(uint categoriaId)
        {
            var byCategory = _context.Services
                .Include(s => s.Categoria)
                .Where(s => s.CategoriaId == categoriaId)
                .ToList();

            return byCategory;
           

        }

        public void Add(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void Delete(uint id)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}
