using ForoAPI.Application.Dtos;
using ForoAPI.Application.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForoAPI.Application.Interfaces
{
    public interface IPostApplication
    {
        Task<BaseResponse<IEnumerable<PostResDto>>> GetAll();
        Task<BaseResponse<PostResDto>> Edit(PostReqDto post);
        Task<BaseResponse<PostResDto>> Delete(int id);
        Task<BaseResponse<PostResDto>> Create(PostCreateDto post);
    }
}
