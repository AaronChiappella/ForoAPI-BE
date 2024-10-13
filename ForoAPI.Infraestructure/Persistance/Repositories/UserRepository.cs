using ForoAPI.Domain.Entities;
using ForoAPI.Infraestructure.Persistance.Context;
using ForoAPI.Infraestructure.Persistance.Interfaces;
using Infrastructure.Commons.Bases;
using Microsoft.EntityFrameworkCore;

namespace ForoAPI.Infraestructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ForoApiDbContext _context;

        public UserRepository(ForoApiDbContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<BaseEntityResponse<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            return new BaseEntityResponse<User>
            {
                TotalRecords = users.Count, // Set the total number of records
                Items = users// Set the retrieved posts
            };
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);

            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }



    }
}
 