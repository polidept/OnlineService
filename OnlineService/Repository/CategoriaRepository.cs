using Microsoft.EntityFrameworkCore;
using OnlineService.Data;
using OnlineService.Interfaces;
using OnlineService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineService.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly ApplicationContext _context;

        public CategoriaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Categoria GetById(uint id)
        {
            var byIdCategoria = _context.Categorias
                .Include(c => c.Services)
                .FirstOrDefault(c => c.Id == id);

            return byIdCategoria;
        }

        public IEnumerable<Categoria> GetAll()
        {
            var allCategoria = _context.Categorias
                .Include(c => c.Services)
                .ToList();

            return allCategoria;
        }

        public void Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void Delete(uint id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
            }
        }
    }
}

