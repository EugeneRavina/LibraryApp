using Library.BFF.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.BFF.Core.Services
{
    public class LibraryService : ILibraryService
    {
        private const string baseUrl = "https://localhost:7268/api/WebApi/LibraryWebApi";

        public LibraryService()
        { }

        public async Task<string> GetAllBooks()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = $"{baseUrl}/books";
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException("Internal Server Error");
                }

                var result = response.Content.ReadAsStringAsync().Result;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> AddBook(BookRequest book)
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = $"{baseUrl}/book";
                HttpResponseMessage response = await client.PostAsJsonAsync(url, book);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException("Internal Server Error");
                }

                var result = response.Content.ReadAsStringAsync().Result;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> GetBookById(int id)
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = $"{baseUrl}/book/{id}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException("Internal Server Error");
                }

                var result = response.Content.ReadAsStringAsync().Result;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateBook(int id, BookRequest bookRequest)
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = $"{baseUrl}/book/{id}";
                HttpResponseMessage response = await client.PutAsJsonAsync(url, bookRequest);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException("Internal Server Error");
                }

                var result = response.Content.ReadAsStringAsync().Result;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}