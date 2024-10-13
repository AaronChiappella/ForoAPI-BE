using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Domain.Entities
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? NickName { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public string Password { get; set; }

        public List<Post>? Posts { get; set; }
    }
}
