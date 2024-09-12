using Library.MicroServices.WebApi.Core.Models;
using Library.MicroServices.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MicroServices.WebApi.Core.Mapper
{
    public static class BookMapper
    {
        public static BookResponse MapToBookResponse(Book book)
        {
            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,
                PublishedDate = book.PublishedDate.ToString("yyyy-MM-dd")
            };
        }
    }
}