using Library.BFF.Models;

namespace Library.BFF.Core.Services
{
    public interface ILibraryService
    {
        Task<List<BookResponse>> GetAllBooks(CancellationToken cancellationToken = default);

        Task<BookResponse> AddBook(BookRequest book, CancellationToken cancellationToken = default);

        Task<BookResponse> GetBookById(int id, CancellationToken cancellationToken = default);

        Task<BookResponse> UpdateBook(int id, BookRequest bookRequest, CancellationToken cancellationToken = default);
    }
}