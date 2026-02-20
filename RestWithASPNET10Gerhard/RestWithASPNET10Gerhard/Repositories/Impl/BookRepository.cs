using RestWithASPNET10Gerhard.Model;
using RestWithASPNET10Gerhard.Model.Context;

namespace RestWithASPNET10Gerhard.Repositories.Impl;

public class BookRepository : IBookRepository
{
    private MSSQLContext _context;

    public BookRepository(MSSQLContext context)
    {
        _context = context;
    }

    public Book Create(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();

        return book;
    }

    public void Delete(long id)
    {
        var existingBook = _context.Books.Find(id);

        if (existingBook is null)
            return;

        _context.Books.Remove(existingBook);
        _context.SaveChanges();
    }

    public List<Book> FindAll()
    {
        return [.. _context.Books];
    }

    public Book FindById(long id)
    {
        return _context.Books.Find(id);
    }

    public Book Update(Book book)
    {
        var existingBook = _context.Books.Find(book.Id);

        if (existingBook is null)
            return null;

        _context.Books.Entry(existingBook).CurrentValues.SetValues(book);
        _context.SaveChanges();

        return existingBook;
    }
}
