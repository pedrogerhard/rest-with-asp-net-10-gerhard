using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Gerhard.Model;
using RestWithASPNET10Gerhard.Services;

namespace RestWithASPNET10Gerhard.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private IBookService _bookService;
    private readonly ILogger<BookController> _logger;

    public BookController(
        IBookService bookService,
        ILogger<BookController> logger
        )
    {
        _bookService = bookService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Fetching all books");

        return Ok(_bookService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        _logger.LogInformation("Fetching book with ID: {Id}", id);

        var book = _bookService.FindById(id);

        if (book == null)
        {
            _logger.LogWarning("Book with ID {id} not found", id);

            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Book book)
    {
        _logger.LogInformation("Creating a new book: {title}", book.Title);

        var createdBook = _bookService.Create(book);

        if (createdBook == null)
        {
            _logger.LogError("Failed to create a book with title {title}", book.Title);

            return NotFound();
        }

        return Ok(book);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Book book)
    {
        _logger.LogInformation("Updating book with id {id}", book.Id);

        var createdBook = _bookService.Update(book);

        if (createdBook == null)
        {
            _logger.LogError("Failed to update book with ID {id}", book.Id);

            return NotFound();
        }
        _logger.LogDebug("Book updated successfully: {bookTitle}", createdBook.Title);

        return Ok(book);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deleting book with ID {id}", id);

        _bookService.Delete(id);

        _logger.LogInformation("Book with ID {id} deleted successfully", id);

        return NoContent();
    }
}
