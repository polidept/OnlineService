using System.Collections.Generic;
using OnlineService.Models;

namespace OnlineService.Interfaces
{
    public interface ISpecialist
    {
        Specialist GetById(uint id);
        IEnumerable<Specialist> GetAll();
        void Add(Specialist specialist);
        void Update(Specialist specialist);
        void Delete(uint id);
    }
}

