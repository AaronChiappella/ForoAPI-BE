using ForoAPI.Application.Dtos;
using ForoAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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



    }
}
