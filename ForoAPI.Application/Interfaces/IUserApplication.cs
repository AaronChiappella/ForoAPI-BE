using ForoAPI.Application.Dtos;
using InventoryApi.Application.Commons;

namespace ForoAPI.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<UserResDto>> GetAll();
        Task<BaseResponse<UserResDto>> Edit(UserReqDto user);
        Task<BaseResponse<UserResDto>> Delete(int id);
        Task<BaseResponse<UserResDto>> Create(UserReqDto user);
    
    }
}
