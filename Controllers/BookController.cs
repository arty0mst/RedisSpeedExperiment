using Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using models;

namespace Controllers
{
    [ApiController]
    [Route("books/")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("getrandom/")]
        public async Task<ActionResult<BookResponse>> GetRandomBook()
        {
            Random rnd = new Random();

            int randomId = rnd.Next(0, 100);

            var book = await _bookService.GetCashed(randomId);

            var response = new BookResponse(book.Id, book.Name, book.Author, book.Genre, book.Pages);

            return Ok(response);
        }

        [HttpPost("create/")]
        public async Task<ActionResult<int>> CreateBook([FromBody] BookRequest request)
        {
            var book = Book.Create
            (
                request.Id,
                request.Name,
                request.Author,
                request.Genre,
                request.Pages
            );

            var bookId = await _bookService.Create(book);

            return bookId;
        }
    }
}