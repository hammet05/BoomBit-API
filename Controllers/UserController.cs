using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBoomBit.Application.DTO;
using TestBoomBit.Application.Interface.Application;
using TestBoomBit.Application.UseCases.Users;

namespace TestBoomBit.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication? _userApplication;
        private readonly IActivitiesApplication? _activitiesApplication;

        public UserController(IUserApplication? userApplication, IActivitiesApplication? activitiesApplication)
        {
            _userApplication = userApplication;
            _activitiesApplication = activitiesApplication;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.IdCountry))
            {
                return BadRequest(new { Message = "El usuario no puede ser vacio." });
            }

            var response = await _userApplication!.Create(userDto);

            if (response.Success)
            {

                //_activitiesApplication.Create()
                return CreatedAtAction(nameof(Create), new { }, response);
            }

            return BadRequest(new { response.Message });
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userApplication!.GetAll();

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(new { response.Message });
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update(int id,[FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest(new { Message = "El usuario no puede ser vacio." });
            }

            var response = await _userApplication!.Update(id,userDto);

            if (response.Success)
            {
                
                return CreatedAtAction(nameof(Create), new { }, response);
            }

            return BadRequest(new { response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _userApplication!.DeleteUserById(id);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response);
        }
    }
}
