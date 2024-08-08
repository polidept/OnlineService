using Microsoft.EntityFrameworkCore;
using OnlineService.Data;
using OnlineService.Interfaces;
using OnlineService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineService.Repositories
{
    public class SpecialistRepository : ISpecialist
    {
        private readonly ApplicationContext _context;

        public SpecialistRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Specialist GetById(uint id)
        {
            var byIdSpecialist = _context.Specialists
                .Include(s => s.Services)
                .FirstOrDefault(s => s.Id == id);

            return byIdSpecialist;
        }

        public IEnumerable<Specialist> GetAll()
        {
            var allSpecialist = _context.Specialists
                .Include(s => s.Services)
                .ToList();

            return allSpecialist;
        }

        public void Add(Specialist specialist)
        {
            _context.Specialists.Add(specialist);
            _context.SaveChanges();
        }

        public void Update(Specialist specialist)
        {
            _context.Specialists.Update(specialist);
            _context.SaveChanges();
        }

        public void Delete(uint id)
        {
            var specialist = _context.Specialists.Find(id);
            if (specialist != null)
            {
                _context.Specialists.Remove(specialist);
                _context.SaveChanges();
            }
        }
    }
}
