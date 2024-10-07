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
    public class UserApplication : IUserApplication
    {
        public Task<BaseResponse<UserResDto>> Create(UserReqDto user)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserResDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserResDto>> Edit(UserReqDto user)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserResDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
