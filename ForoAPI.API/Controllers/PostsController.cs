using ForoAPI.Application.Dtos;
using ForoAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForoAPI.API.Controllers
{
    public class PostsController : ControllerBase
    {
        private readonly IPostApplication _postsService;

        public PostsController(IPostApplication postsService)
        {
        _postsService = postsService; 
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _postsService.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response); // Handling the case where the response fails
        }

        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PostCreateDto requestDto)
        {
            if (!ModelState.IsValid) // Validation check for the DTO
            {
                return BadRequest(ModelState);
            }

            var response = await _postsService.Create(requestDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response); // Handling failure in user creation
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _postsService.Delete(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return NotFound(response); // Return 404 if the user doesn't exist
        }

        // PUT: api/Posts/Edit --> CAMBIAR AUTHOR EMAIL NULLEABLE
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] PostReqDto requestDto)
        {
            if (!ModelState.IsValid) // Validation check for the DTO
            {
                return BadRequest(ModelState);
            }

            var response = await _postsService.Edit(requestDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response); // Return 404 if the user doesn't exist
        }

    }
}
