using System;
using CentralLibrary.API.Dto;
using CentralLibrary.Domain.Exceptions;
using CentralLibrary.Domain.Model;
using CentralLibrary.Domain.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public RegistrationController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public IActionResult Register(NewMemberDto dto)
        {
            try
            {
                int memberNumber = _memberService.RegisterMember(new Member
                {
                    Address = dto.Address,
                    Jmbg = dto.Jmbg,
                    Name = dto.Name,
                    Surname = dto.Surname,
                });
                return Ok("New member added. Member number: " + memberNumber);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case NotFoundException: return NotFound(ex.Message);
                    case RentalNumberException: return Conflict(ex.Message);
                    default: return Problem("Oops, something went wrong, try again!");
                }
            }
        } 
    }
}
