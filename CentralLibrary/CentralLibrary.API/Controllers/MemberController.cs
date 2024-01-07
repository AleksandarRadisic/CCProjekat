using System;
using CentralLibrary.API.Dto;
using CentralLibrary.Domain.Exceptions;
using CentralLibrary.Domain.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CentralLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_memberService.GetAll());
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {
            return Ok("Ok");
        }

        [HttpPut("Rent")]
        public IActionResult CheckAndAddRent(RentDto dto)
        {
            try
            {
                _memberService.AddRent(dto.MemberNumber);
                return Ok("Rent documented");
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case RentalNumberException: return Conflict(ex.Message);
                    case NotFoundException: return NotFound(ex.Message);
                    default: return Problem("Oops, something went wrong, try again");
                }
            }
        }

        [HttpPut("Return")]
        public IActionResult ReturnBook(RentDto dto)
        {
            try
            {
                _memberService.ReturnRented(dto.MemberNumber);
                return Ok("Rent return documented");
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case RentalNumberException: return Conflict(ex.Message);
                    case NotFoundException: return NotFound(ex.Message);
                    default: return Problem("Oops, something went wrong, try again");
                }
            }
        }
    }
}
