using Library.MicroServices.WebApi.Core;
using Library.MicroServices.WebApi.Core.Mapper;
using Library.MicroServices.WebApi.Core.Models;
using Library.MicroServices.WebApi.Models;
using Library.MicroServices.WebApi.Repositories.Library;
using System.Globalization;

namespace Library.MicroService.WebApi.Core
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<List<BookResponse>> GetAllBooksAsync()
        {
            return await _libraryRepository.GetAllBooksAsync();
        }

        public async Task<BookResponse> InsertBookAsync(BookRequest bookRequest)
        {
            var book = new Book
            {
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                Isbn = bookRequest.Isbn,
                PublishedDate = ConvertStringToDateTimeFormat(bookRequest.PublishedDate),
            };

            var newBook = await _libraryRepository.AddAsync(book);

            return BookMapper.MapToBookResponse(newBook);
        }

        public async Task<BookResponse> GetBookById(int id)
        {
            var book = await _libraryRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new ArgumentException("The Book is not exist");
            }
            return BookMapper.MapToBookResponse(book);
        }

        public async Task<BookResponse> UpdateBook(int id, BookRequest book)
        {
            var findBook = await _libraryRepository.GetByIdAsync(id);

            if (findBook == null)
            {
                throw new ArgumentException("The Book is not exist");
            }

            findBook.Title = book.Title;
            findBook.Author = book.Author;
            findBook.Isbn = book.Isbn;
            findBook.PublishedDate = ConvertStringToDateTimeFormat(book.PublishedDate);

            var updatedBook = await _libraryRepository.UpdateAsync(findBook);

            return BookMapper.MapToBookResponse(updatedBook);
        }

        private DateTime ConvertStringToDateTimeFormat(string? dateTime)
        {
            DateTime date;
            if (!string.IsNullOrEmpty(dateTime))
            {
                bool success = DateTime.TryParseExact(dateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                return success ? date : DateTime.Now;
            }
            return DateTime.Now;
        }
    }
}