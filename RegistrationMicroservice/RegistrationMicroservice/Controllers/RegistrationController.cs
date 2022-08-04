using log4net;
using Microsoft.AspNetCore.Mvc;
using RegistrationMicroservice.Database;
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
        private readonly ILog _logger = LogManager.GetLogger(typeof(RegistrationController));
        
        public RegistrationController(IRegRepository regRepository, RegistrationContext registrationContext)
        {
            _regRepository = regRepository;          
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllRegistrations()
        {
            _logger.Info("Action Started");
            var registrations = await _regRepository.GetAllRegistrationsAsync();
            _logger.Info("Successfully executed");
            return Ok(registrations);
            

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationByID([FromRoute] int id)
        {
            _logger.Info("Action Started");
            var registration = await _regRepository.GetRegistrationByIDAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            _logger.Info("Successfully executed");
            return Ok(registration);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddRegistration([FromBody] RegistrationModel registrationModel)
        {
            _logger.Info("Action Started");
            var id = await _regRepository.AddRegistrationAsync(registrationModel);
            _logger.Info("Successfully executed");
            return CreatedAtAction(nameof(GetRegistrationByID), new { id = id, controller = "registration" }, id);
          
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration([FromBody] RegistrationModel registrationModel, [FromRoute] int id)
        {
            _logger.Info("Action Started");
            await _regRepository.UpdateRegistrationAsync(id, registrationModel);
            _logger.Info("Successfully executed");
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration([FromBody] RegistrationModel registrationModel, [FromRoute] int id)
        {
            _logger.Info("Action Started");
            await _regRepository.DeleteRegistrationAsync(id, registrationModel);
            _logger.Info("Successfully executed");
            return Ok();
        }


    }
        

    }

