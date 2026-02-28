using RestWithASPNET10Gerhard.Data.Converter.Impl;
using RestWithASPNET10Gerhard.Data.DTO;
using RestWithASPNET10Gerhard.Model;
using RestWithASPNET10Gerhard.Repositories;

namespace RestWithASPNET10Gerhard.Services.Impl;

public class PersonServicesImpl : IPersonServices
{
    private Irepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonServicesImpl(Irepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }

    public List<PersonDTO> FindAll()
    {
        return _converter.ParseList(_repository.FindAll());
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Create(entity);

        return _converter.Parse(entity);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }

    public PersonDTO FindById(long id)
    {

        return _converter.Parse(_repository.FindById(id));
    }

    public PersonDTO Update(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Update(entity);

        return _converter.Parse(entity);
    }
}
