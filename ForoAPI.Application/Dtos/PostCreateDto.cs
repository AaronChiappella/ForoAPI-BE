using ForoAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Application.Dtos
{
    public class PostCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public string AuthorEmail { get; set; }
    }
}
