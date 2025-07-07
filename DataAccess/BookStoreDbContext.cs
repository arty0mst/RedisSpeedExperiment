using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {

    }

    public DbSet<BookEntity> Books { get; set; }
}