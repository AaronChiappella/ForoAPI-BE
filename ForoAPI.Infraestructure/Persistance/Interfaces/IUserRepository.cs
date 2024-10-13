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
        public Task<BaseEntityResponse<User>> GetAll();
        public Task<User> Add(User user);
        public Task<User> Update(User user);
        public Task<User> Delete(User user);

        public Task<User> GetById(int id);

        public Task<User> GetByEmail(string email);

    }
}
