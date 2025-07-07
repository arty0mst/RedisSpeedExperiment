using models;

namespace Abstractions
{
    public interface IBookRepository
    {
        public Task<List<Book>> Get();
        public Task<int> Create(Book book);

    }
}