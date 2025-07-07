using System.Text.Json;
using Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using models;

namespace Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IDistributedCache _bookCache;

        public BookService(IBookRepository bookRepository, IDistributedCache bookCache)
        {
            _bookRepository = bookRepository;
            _bookCache = bookCache;
        }

        public async Task<Book> Get(int id)
        {
            var books = await _bookRepository.Get();

            return books
                .Where(b => b.Id == id)
                .FirstOrDefault()!;
        }

        public async Task<Book> GetCashed(int id)
        {
            Book? book = null;

            string key = $"bookId:{id}";

            var bookRow = await _bookCache.GetStringAsync(key);

            if (bookRow != null)
            {
                book = JsonSerializer.Deserialize<Book>(bookRow);
            }
            if (bookRow == null)
            {
                var books = await _bookRepository.Get();
                book = books
                    .Where(b => b.Id == id)
                    .FirstOrDefault()!;

                bookRow = JsonSerializer.Serialize(book);
                
                await _bookCache.SetStringAsync(key, bookRow, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3)
                });
            }

            return book!;
        }

        public async Task<int> Create(Book book)
        {
            return await _bookRepository.Create(book);
        }

    }
}