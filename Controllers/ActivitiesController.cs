using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBoomBit.Application.DTO;
using TestBoomBit.Application.Interface.Application;

namespace TestBoomBit.Controllers
{
    [Route("api/activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
       private readonly IActivitiesApplication? _activitiesApplication;
        public ActivitiesController(IActivitiesApplication? activitiesApplication)
        {
            _activitiesApplication = activitiesApplication;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ActivitiesDto activityDto)
        {
            if (activityDto == null ||string.IsNullOrEmpty(activityDto.ActivityDescription))
            {
                return BadRequest(new { Message = "La actividad no puede estar vacia." });
            }

            var response = await _activitiesApplication!.Create(activityDto);

            if (response.Success)
            {
                return CreatedAtAction(nameof(Create), new { }, response);
            }

            return BadRequest(new { response.Message });
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _activitiesApplication!.GetAll();

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(new {  response.Message });
        }
    }
}
