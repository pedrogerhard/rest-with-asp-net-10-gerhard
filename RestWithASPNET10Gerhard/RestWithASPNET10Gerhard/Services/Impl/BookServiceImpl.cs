using Mapster;
using RestWithASPNET10Gerhard.Data.DTO.V1;
using RestWithASPNET10Gerhard.Model;
using RestWithASPNET10Gerhard.Repositories;

namespace RestWithASPNET10Gerhard.Services.Impl;

//teste
public class BookServiceImpl : IBookService
{
    private Irepository<Book> _repository;

    public BookServiceImpl(Irepository<Book> repository)
    {
        _repository = repository;
    }

    public BookDTO Create(BookDTO book)
    {
        var entity = book.Adapt<Book>();

        entity = _repository.Create(entity);

        return entity.Adapt<BookDTO>();
    }

    public void Delete(long id)
    {
         _repository.Delete(id);
    }

    public List<BookDTO> FindAll()
    {
        return _repository.FindAll().Adapt<List<BookDTO>>();
    }

    public BookDTO FindById(long id)
    {
        return _repository.FindById(id).Adapt<BookDTO>();
    }

    public BookDTO Update(BookDTO book)
    {
        var entity = book.Adapt<Book>();

        entity = _repository.Update(entity);

        return entity.Adapt<BookDTO>();
    }
}
