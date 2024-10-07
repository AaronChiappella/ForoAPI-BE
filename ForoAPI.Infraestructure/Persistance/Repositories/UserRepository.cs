using ForoAPI.Domain.Entities;
using ForoAPI.Infraestructure.Persistance.Context;
using ForoAPI.Infraestructure.Persistance.Interfaces;
using Infrastructure.Commons.Bases;

namespace ForoAPI.Infraestructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ForoApiDbContext _context;

        public UserRepository(ForoApiDbContext context) 
        {
            _context = context;
        }
        public Task<User> Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Edit(User user)
        {
            throw new NotImplementedException();
        }

        public Task<BaseEntityResponse<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
