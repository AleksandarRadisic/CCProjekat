using System;
using CityLibrary.API.Dto;
using CityLibrary.Domain.Exceptions;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRentalController : ControllerBase
    {
        private readonly IBookRentalService _bookRentalService;
        public BookRentalController(IBookRentalService bookRentalService)
        {
            _bookRentalService = bookRentalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookRentalService.GetAll());
        }

        [HttpPost]
        public IActionResult RentBook(BookRentalDto dto)
        {
            try
            {
                _bookRentalService.RentBook(new Book
                {
                    ISBN = dto.ISBN,
                    Title = dto.Title,
                    Writer = dto.Writer
                }, dto.MemberNumber);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case NotFoundException: return NotFound(ex.Message);
                    case BookNotAvailableException: return Conflict(ex.Message);
                    default: return Problem("Oops, something went wrong, try again!");
                }
            }

            return Ok("Book rented");
        }

        [HttpPut]
        public IActionResult ReturnBook(ReturnBookDto dto)
        {
            try
            {
                _bookRentalService.ReturnBook(dto.Isbn, dto.MemberNumber);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case NotFoundException: return NotFound(ex.Message);
                    default: return Problem("Oops, something went wrong, try again!");
                }
            }

            return Ok("Book returned");
        }
    }
}
