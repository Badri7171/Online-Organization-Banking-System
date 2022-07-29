using Microsoft.AspNetCore.Mvc;
using RegistrationMicroservice.Database.Entities;
using RegistrationMicroservice.Repositories;
using System.Threading.Tasks;

namespace RegistrationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegistrationController : ControllerBase
    {
        private readonly IRegRepository _regRepository;
        public RegistrationController(IRegRepository regRepository)
        {
            _regRepository = regRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var registrations = await _regRepository.GetAllRegistrationsAsync();
            return Ok(registrations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationByID([FromRoute]int id)
        {
            var registration = await _regRepository.GetRegistrationByIDAsync(id);
            if(registration == null)
            {
                return NotFound();
            }
            return Ok(registration);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddRegistration([FromBody]RegistrationModel registrationModel)
        {
            var id = await _regRepository.AddRegistrationAsync(registrationModel);
            return CreatedAtAction(nameof(GetRegistrationByID), new { id = id, controller = "registration" }, id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration([FromBody] RegistrationModel registrationModel, [FromRoute] int id)
        {
            await _regRepository.UpdateRegistrationAsync(id, registrationModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration([FromBody] RegistrationModel registrationModel, [FromRoute] int id)
        {
            await _regRepository.DeleteRegistrationAsync(id, registrationModel);
            return Ok();
        }
    }
}
