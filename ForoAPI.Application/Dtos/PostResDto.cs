﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Application.Dtos
{
    public class PostResDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }

        public UserResDto? Author { get; set; }
    }
}