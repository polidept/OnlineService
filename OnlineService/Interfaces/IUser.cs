using System.Collections.Generic;
using OnlineService.Models;

namespace OnlineService.Interfaces
{
    public interface IUser
    {
        User GetById(uint id);
        IEnumerable<User> GetAll();
        IEnumerable<Order> GetByUser(uint userId);
        void Add(User user);
        void Update(User user);
        void Delete(uint id);
    }
}


