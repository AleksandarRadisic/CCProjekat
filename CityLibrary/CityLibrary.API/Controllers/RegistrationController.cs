using System;
using CityLibrary.Domain.Exceptions;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.Services.Interface;
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
            try
            {
                return Ok(_registrationService.RegisterMember(member));
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(AggregateException)) ex = ex.InnerException;
                switch (ex)
                {
                    case NotFoundException: return NotFound(ex.Message);
                    case ConflictException: return Conflict(ex.Message);
                    default: return Problem("Oops, something went wrong, try again!");
                }
            }
        } 
    }
}
