using CityLibrary.Domain.Model;
using CityLibrary.Domain.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public IActionResult Register(Member member)
        {
            _registrationService.RegisterMember(member);
            return Problem("Call central library, not implelented");
        } 
    }
}
