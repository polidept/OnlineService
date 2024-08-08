using System.Collections.Generic;
using OnlineService.Models;

namespace OnlineService.Interfaces
{
    public interface IService
    {
        Service GetById(uint Id);
        IEnumerable<Service> GetAll();
        IEnumerable<Service> GetByCategory(uint CategoryId);
        void Add(Service Service);
        void Update(Service Service);
        void Delete(uint Id);
    }
}
