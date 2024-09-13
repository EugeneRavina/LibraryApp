using Library.BFF.Core.Services;
using Library.BFF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.BFF.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryBffApiController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryBffApiController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var result = await _libraryService.GetAllBooks();
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
                var result = await _libraryService.AddBook(bookRequest);
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