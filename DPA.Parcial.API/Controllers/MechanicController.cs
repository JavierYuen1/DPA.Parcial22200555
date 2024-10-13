using DPA.Parcial.DOMAIN.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Parcial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {
        private readonly IMechanicRepository _mechanicRepository;
        public MechanicController(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMechanic()
        {
            var mechanic = await _mechanicRepository.GetMechanies();
            return Ok(mechanic);
        }
    }
}
