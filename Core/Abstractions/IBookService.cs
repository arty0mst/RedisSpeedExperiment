using models;

namespace Abstractions
{
    public interface IBookService
    {
        public Task<Book> Get(int id);
        public  Task<Book> GetCashed(int id);
        public Task<int> Create(Book book);
    }
}