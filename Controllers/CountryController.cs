using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBoomBit.Application.DTO;
using TestBoomBit.Application.Interface.Application;

namespace TestBoomBit.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryApplication? _countryApplication;

        public CountryController(ICountryApplication? countryApplication)
        {
            _countryApplication = countryApplication;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _countryApplication!.GetAll(); 

            if (response.Success) 
            {
                return Ok(response);
            }

            return BadRequest(new { Message = response.Message }); 
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CountriesDto countriesDto)
        {
            if (countriesDto == null)
            {
                return BadRequest(new { Message = "El país  no puede ser nulo." });
            }

            var response = await _countryApplication!.Create(countriesDto); 

            if (response.Success)
            {
                return CreatedAtAction(nameof(GetAll), new { }, response);
            }

            return BadRequest(new { Message = response.Message }); 
        }
    }
}
