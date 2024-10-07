using AutoMapper;
using ForoAPI.Application.Dtos;
using ForoAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Application.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {

            //USERS
            CreateMap<User, UserResDto>();
            CreateMap<UserReqDto, User>();


            //POSTS
            CreateMap<Post,PostResDto>();
            CreateMap<PostReqDto, Post>();


        }
    }
}
