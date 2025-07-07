using Entities;
using Microsoft.EntityFrameworkCore;
using models;
using Abstractions;

public class BookRepository : IBookRepository
{
    private readonly BookStoreDbContext _context;

    public BookRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> Get()
    {
        var booksEntities = await _context.Books
            .AsNoTracking()
            .ToListAsync();

        var books = booksEntities
            .Select(b => Book.Create(b.Id, b.Name, b.Author, b.Genre, b.Pages))
            .ToList();

        return books;
    }

    public async Task<int> Create(Book book)
    {
        var bookEntity = new BookEntity
        {
            Id = book.Id,
            Name = book.Name,
            Author = book.Author,
            Genre = book.Genre,
            Pages = book.Pages,
        };

        await _context.Books.AddAsync(bookEntity);
        await _context.SaveChangesAsync();

        return bookEntity.Id;
    }
}