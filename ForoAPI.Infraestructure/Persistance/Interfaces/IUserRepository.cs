using ForoAPI.Domain.Entities;
using Infrastructure.Commons.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Infraestructure.Persistance.Interfaces
{
    public interface IUserRepository
    {
        public Task<BaseEntityResponse<User>> GetUsers();
        public Task<User> Add(User user);
        public Task<User> Edit(User user);
        public Task<User> Delete(User user);



    }
}
