using RestWithASPNET10Gerhard.Model;

namespace RestWithASPNET10Gerhard.Services;

public interface IBookService
{
    Book Create(Book book);

    Book FindById(long id);

    List<Book> FindAll();

    Book Update(Book book);

    void Delete(long id);
}
