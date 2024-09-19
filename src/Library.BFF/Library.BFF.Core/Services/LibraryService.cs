using Library.BFF.Models;
using System.Text;
using System.Text.Json;

namespace Library.BFF.Core.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string baseUrl = "https://localhost:7268/api/WebApi/LibraryWebApi";

        public LibraryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<BookResponse>> GetAllBooks(CancellationToken cancellationToken = default)
        {
            using var httpClient = _httpClientFactory.CreateClient();

            try
            {
                using var response = await httpClient.GetAsync($"{baseUrl}/books", cancellationToken);

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
                var books = JsonSerializer.Deserialize<List<BookResponse>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return books ?? new List<BookResponse>();
            }
            catch (HttpRequestException httpEx)
            {
                // Log the error or handle it accordingly
                throw new Exception("Error fetching book data", httpEx);
            }
            catch (JsonException jsonEx)
            {
                // Handle JSON deserialization errors
                throw new Exception("Error parsing the book response", jsonEx);
            }
        }

        public async Task<BookResponse> AddBook(BookRequest book, CancellationToken cancellationToken = default)
        {
            using var httpClient = _httpClientFactory.CreateClient();

            try
            {
                var requestContent = new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json");
                using var response = await httpClient.PostAsync($"{baseUrl}/book", requestContent, cancellationToken);

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
                var newBook = JsonSerializer.Deserialize<BookResponse>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return newBook ?? new BookResponse();
            }
            catch (HttpRequestException httpEx)
            {
                // Log the error or handle it accordingly
                throw new Exception("Error creating book data", httpEx);
            }
            catch (JsonException jsonEx)
            {
                // Handle JSON deserialization errors
                throw new Exception("Error parsing the book response", jsonEx);
            }
        }

        public async Task<BookResponse> GetBookById(int id, CancellationToken cancellationToken = default)
        {
            using var httpClient = _httpClientFactory.CreateClient();

            try
            {
                using var response = await httpClient.GetAsync($"{baseUrl}/book/{id}", cancellationToken);

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
                var book = JsonSerializer.Deserialize<BookResponse>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return book ?? new BookResponse();
            }
            catch (HttpRequestException httpEx)
            {
                // Log the error or handle it accordingly
                throw new Exception("Error fetching book data", httpEx);
            }
            catch (JsonException jsonEx)
            {
                // Handle JSON deserialization errors
                throw new Exception("Error parsing the book response", jsonEx);
            }
        }

        public async Task<BookResponse> UpdateBook(int id, BookRequest bookRequest, CancellationToken cancellationToken = default)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            try
            {
                var requestContent = new StringContent(JsonSerializer.Serialize(bookRequest), Encoding.UTF8, "application/json");
                using var response = await httpClient.PutAsync($"{baseUrl}/book/{id}", requestContent, cancellationToken);

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
                var updatedBook = JsonSerializer.Deserialize<BookResponse>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return updatedBook;
            }
            catch (HttpRequestException httpEx)
            {
                // Log the error or handle it accordingly
                throw new Exception("Error fetching book data", httpEx);
            }
            catch (JsonException jsonEx)
            {
                // Handle JSON deserialization errors
                throw new Exception("Error parsing the book response", jsonEx);
            }
        }
    }
}