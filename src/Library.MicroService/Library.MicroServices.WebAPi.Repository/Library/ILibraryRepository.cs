using Library.MicroServices.WebApi.Core.Models;
using Library.MicroServices.WebApi.Models;

namespace Library.MicroServices.WebApi.Repositories.Library
{
    public interface ILibraryRepository : IRepository<Book>
    {
        Task<List<BookResponse>> GetAllBooksAsync();
    }
}