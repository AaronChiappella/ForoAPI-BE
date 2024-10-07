using ForoAPI.Domain.Entities;
using Infrastructure.Commons.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Infraestructure.Persistance.Interfaces
{
    public interface IPostRepository
    {
        public Task<Post> Add(Post post, User author);
        public Task<Post> Edit(Post post);
        public Task<Post> Delete(Post post);
    }
}
