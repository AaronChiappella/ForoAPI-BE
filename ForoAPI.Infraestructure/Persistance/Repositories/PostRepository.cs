using ForoAPI.Domain.Entities;
using ForoAPI.Infraestructure.Persistance.Context;
using ForoAPI.Infraestructure.Persistance.Interfaces;
using Infrastructure.Commons.Bases;

namespace ForoAPI.Infraestructure.Persistance.Repositories
{
    public class PostRepository : IPostRepository
    {



        private readonly ForoApiDbContext _context;

        public PostRepository(ForoApiDbContext context)
        {
            _context = context;
        }
        public async Task<Post> Add(Post post, User author)
        {
            post.Author= author; // Set the author of the post
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> Delete(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> Edit(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }


    }
}
