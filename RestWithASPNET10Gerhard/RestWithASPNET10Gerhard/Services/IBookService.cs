using RestWithASPNET10Gerhard.Data.DTO.V1;
using RestWithASPNET10Gerhard.Model;

namespace RestWithASPNET10Gerhard.Services;

public interface IBookService
{
    BookDTO Create(BookDTO book);

    BookDTO FindById(long id);

    List<BookDTO> FindAll();

    BookDTO Update(BookDTO book);

    void Delete(long id);
}
