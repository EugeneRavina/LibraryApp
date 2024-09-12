using Library.MicroServices.WebApi.Core;
using Library.MicroServices.WebApi.Core.Models;
using Library.MicroServices.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Library.MicroServices.WebApi.Controllers
{
    public class LibraryWebApiController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryWebApiController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var result = await _libraryService.GetAllBooksAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> AddBook([FromBody] BookRequest bookRequest)
        {
            try
            {
                var result = await _libraryService.InsertBookAsync(bookRequest);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("book/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var result = await _libraryService.GetBookById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("book/{id}")]
        public async Task<IActionResult> UpdateBookById(int id, [FromBody] BookRequest bookRequest)
        {
            try
            {
                var result = await _libraryService.UpdateBook(id, bookRequest);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}