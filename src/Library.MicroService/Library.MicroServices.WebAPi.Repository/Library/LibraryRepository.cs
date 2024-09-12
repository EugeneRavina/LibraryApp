using Library.MicroServices.WebApi.Core.Models;
using Library.MicroServices.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MicroServices.WebApi.Repositories.Library
{
    public class LibraryRepository : Repository<Book>, ILibraryRepository
    {
        private readonly LibraryDbContext _context;

        public LibraryRepository(LibraryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<BookResponse>> GetAllBooksAsync()
        {
            return await _context.Set<Book>()
                .Select(book => new BookResponse
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Isbn = book.Isbn,
                    PublishedDate = book.PublishedDate.ToString("yyyy-MM-dd")
                }).ToListAsync();
        }
    }
}