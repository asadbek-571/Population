using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Population.Entity;

namespace Population.Repository
{
    public interface IUserRepo
    {
        Task<User> Get(Guid id);
        Task<IEnumerable<User>> GetAll();

        Task Add(User user);
        
        Task Delete(Guid id);
        
        Task Update(User user,Guid id);
    }
}