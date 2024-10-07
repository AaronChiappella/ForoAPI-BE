using ForoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForoAPI.Infraestructure.Persistance.Context
{
    public class ForoApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        // Constructor
        public ForoApiDbContext(DbContextOptions<ForoApiDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User-Post relationship (One-to-Many)
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(u => u.Posts);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
