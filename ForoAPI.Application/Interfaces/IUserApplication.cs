using ForoAPI.Application.Dtos;
using ForoAPI.Application.Commons;

namespace ForoAPI.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<IEnumerable<UserResDto>>> GetAll();
        Task<BaseResponse<UserResDto>> Edit(UserReqDto user);
        Task<BaseResponse<UserResDto>> Delete(int id);
        Task<BaseResponse<UserResDto>> Create(UserReqDto user);

        Task<BaseResponse<UserResDto>> Authenticate(UserLoginDto loginDto);
    }
}
