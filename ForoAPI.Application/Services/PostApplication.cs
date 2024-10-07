using ForoAPI.Application.Dtos;
using ForoAPI.Application.Interfaces;
using InventoryApi.Application.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Application.Services
{
    public class PostApplication : IPostApplication
    {
        public Task<BaseResponse<PostResDto>> Create(PostReqDto post)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<PostResDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<PostResDto>> Edit(PostReqDto post)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<PostResDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
