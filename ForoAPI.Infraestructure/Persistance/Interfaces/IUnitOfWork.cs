using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Infraestructure.Persistance.Interfaces
{
    internal interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IPostRepository Posts { get; }
    }
}
