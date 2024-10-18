using ForoAPI.Application.Dtos;
using ForoAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserApplication _userService;

        public UsersController(IUserApplication userService)
        {
            _userService= userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response); // Handling the case where the response fails
        }

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Create([FromBody] UserReqDto requestDto)
        {
            if (!ModelState.IsValid) // Validation check for the DTO
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.Create(requestDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response); // Handling failure in user creation
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _userService.Delete(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return NotFound(response); // Return 404 if the user doesn't exist
        }

        // PUT: api/Users/Edit
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] UserReqDto requestDto)
        {
            if (!ModelState.IsValid) // Validation check for the DTO
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.Edit(requestDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response); // Return 404 if the user doesn't exist
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.Authenticate(loginDto);

            if (response.IsSuccess)
            {
                var token = GenerateJwtToken(response.Data); // Genera el token JWT
                                                             // Crea un objeto que contenga la respuesta y el token
                var result = new
                {
                    Response = response,
                    Token = token
                };
                return Ok(result); // Devuelve el objeto con la respuesta y el token
            }

            return Unauthorized(response);
        }

        private string GenerateJwtToken(UserResDto user)
        {
            // Token generation logic, e.g. using JwtSecurityTokenHandler
            // Define claims, token expiration, and signing credentials here
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TuClaveSeguraYLoSuficientementeLarga123"); // Use a secure key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString())
                    // Add other claims as needed
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Set token expiration
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
