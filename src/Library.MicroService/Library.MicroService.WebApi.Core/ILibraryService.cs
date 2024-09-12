using Library.MicroServices.WebApi.Core.Models;
using Library.MicroServices.WebApi.Models;

namespace Library.MicroServices.WebApi.Core
{
    public interface ILibraryService
    {
        Task<List<BookResponse>> GetAllBooksAsync();

        Task<BookResponse> InsertBookAsync(BookRequest book);

        Task<BookResponse> GetBookById(int id);

        Task<BookResponse> UpdateBook(int id, BookRequest book);
    }
}