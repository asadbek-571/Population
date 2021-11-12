

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Population.Data;
using Population.Entity;

namespace Population.Repository.impl
{
    public class UserRepo : IUserRepo
    {
        private readonly IDataContext _context;

        public UserRepo(IDataContext context)
        {
            _context = context;
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task Add(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var itemToDelete = await _context.User.FindAsync(id);

            if (itemToDelete == null)
             throw new NullReferenceException("User doesn't exist");
            
            _context.User.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user,Guid id)
        {
            var itemToUpdate = await _context.User.FindAsync(id);

            if (itemToUpdate==null)
                throw new NullReferenceException("User doesn't exist");

            itemToUpdate.FirstName = user.FirstName;
            itemToUpdate.LastName = user.LastName;
            itemToUpdate.Gender = user.Gender;
            itemToUpdate.Birthday = user.Birthday;
            itemToUpdate.HomeNumber = user.HomeNumber;
            itemToUpdate.District = user.District;
            await _context.SaveChangesAsync();
        }
    }
}