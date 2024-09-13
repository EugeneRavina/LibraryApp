using Library.BFF.Models;

namespace Library.BFF.Core.Services
{
    public interface ILibraryService
    {
        Task<string> GetAllBooks();

        Task<string> AddBook(BookRequest book);

        Task<string> GetBookById(int id);

        Task<string> UpdateBook(int id, BookRequest bookRequest);
    }
}