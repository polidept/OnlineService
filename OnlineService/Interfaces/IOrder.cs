using System.Collections.Generic;
using OnlineService.Models;

namespace OnlineService.Interfaces
{
    public interface IOrder
    {
        Order GetById(uint id);
        IEnumerable<Order> GetAll();
        void Add(Order order);
        void Update(Order order);
        void Delete(uint id);
    }
}
