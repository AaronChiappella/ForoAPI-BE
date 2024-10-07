using ForoAPI.Infraestructure.Persistance.Context;
using ForoAPI.Infraestructure.Persistance.Interfaces;

namespace ForoAPI.Infraestructure.Persistance.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ForoApiDbContext _context;

        public UnitOfWork(ForoApiDbContext context)
        {

            _context = context;

            Users = new UserRepository(_context);
            Posts = new PostRepository(_context);



        }
    
        public IUserRepository Users { get; }
        public IPostRepository Posts { get; }
    
    
    
    
    
    }
}
