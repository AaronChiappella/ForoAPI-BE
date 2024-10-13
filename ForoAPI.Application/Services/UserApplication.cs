using AutoMapper;
using ForoAPI.Application.Dtos;
using ForoAPI.Application.Interfaces;
using ForoAPI.Domain.Entities;
using ForoAPI.Infraestructure.Persistance.Interfaces;
using ForoAPI.Application.Commons;
using Utilities.Statics;

namespace ForoAPI.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<UserResDto>> Authenticate(UserLoginDto loginDto)
        {
            var response = new BaseResponse<UserResDto>();

            // Buscar al usuario por su email
            var user = await _unitOfWork.Users.GetByEmail(loginDto.Email); // Cambia esto por tu método de repositorio para obtener el usuario por email.

            // Verificar si se encontró un usuario y si la contraseña ingresada es correcta
            if (user != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                // Si la contraseña es válida, retornar éxito
                response.IsSuccess = true;
                response.Data = _mapper.Map<UserResDto>(user);
                response.Message = ReplyMessages.MESSAGE_QUERY;
            }
            else
            {
                // Si no, retornar fallo con mensaje de error
                response.IsSuccess = false;
                response.Message = "Email o contraseña incorrectos";
            }

            return response;
        }



        public async Task<BaseResponse<UserResDto>> Create(UserReqDto userReqDto)
        {
            var response = new BaseResponse<UserResDto>();

            // Cifrar la contraseña antes de guardar
            userReqDto.Password = BCrypt.Net.BCrypt.HashPassword(userReqDto.Password);

            var user = _mapper.Map<User>(userReqDto);
            user.Activo = true;
            var newUser = await _unitOfWork.Users.Add(user);

            response.IsSuccess = true;
            response.Data = _mapper.Map<UserResDto>(newUser);
            response.Message = ReplyMessages.MESSAGE_QUERY;

            return response;
        }


        public async Task<BaseResponse<UserResDto>> Delete(int id)
        {
            var response = new BaseResponse<UserResDto>();

            // Retrieve the user by id
            var user = await _unitOfWork.Users.GetById(id);

            if (user != null)
            {
                // Delete the user if it exists
                await _unitOfWork.Users.Delete(user);
                response.IsSuccess = true;
                response.Message = ReplyMessages.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessages.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<UserResDto>> Edit(UserReqDto userReqDto)
        {
            var response = new BaseResponse<UserResDto>();

            // Check if Id has a value
            if (!userReqDto.Id.HasValue)
            {
                response.IsSuccess = false;
                response.Message = "User ID is required";
                return response;
            }

            // Retrieve the user to be updated
            var existingUser = await _unitOfWork.Users.GetById(userReqDto.Id.Value);  // Use .Value to pass the int

            if (existingUser != null)
            {
                // Map updated values to the existing user entity
                _mapper.Map(userReqDto, existingUser);

                // Update the user in the repository
                await _unitOfWork.Users.Update(existingUser);

                response.IsSuccess = true;
                response.Data = _mapper.Map<UserResDto>(existingUser);
                response.Message = ReplyMessages.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessages.MESSAGE_FAILED;
            }

            return response;
        }


        public async Task<BaseResponse<IEnumerable<UserResDto>>> GetAll()
        {
            var response = new BaseResponse<IEnumerable<UserResDto>>();

            // Retrieve all users from the repository
            var users = await _unitOfWork.Users.GetAll();

            if (users.Items != null && users.Items.Any())
            {
                response.IsSuccess = true;
                // Map the list of users to a collection of UserResDto
                response.Data = _mapper.Map<IEnumerable<UserResDto>>(users.Items);
                response.Message = ReplyMessages.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessages.MESSAGE_FAILED;
            }

            return response;
        }





    }
}
