using System.Collections.Generic;
using OnlineService.Models;

namespace OnlineService.Interfaces
{
    public interface ICategoria
    {
        Categoria GetById(uint id);
        IEnumerable<Categoria> GetAll();
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(uint id);
    }
}

