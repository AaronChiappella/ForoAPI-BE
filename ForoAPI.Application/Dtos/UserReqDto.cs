﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Application.Dtos
{
    public class UserReqDto
    {
        public int? Id { get; set; }
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public bool Activo { get; set; }
    }
}