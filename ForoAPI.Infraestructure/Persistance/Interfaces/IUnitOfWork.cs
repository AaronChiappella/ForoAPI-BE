namespace ForoAPI.Infraestructure.Persistance.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IPostRepository Posts { get; }
    }
}
