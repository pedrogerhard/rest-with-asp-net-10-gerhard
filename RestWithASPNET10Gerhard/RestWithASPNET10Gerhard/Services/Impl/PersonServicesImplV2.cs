using RestWithASPNET10Gerhard.Data.Converter.Impl;
using RestWithASPNET10Gerhard.Data.DTO.V2;
using RestWithASPNET10Gerhard.Model;
using RestWithASPNET10Gerhard.Repositories;

namespace RestWithASPNET10Gerhard.Services.Impl;

public class PersonServicesImplV2 
{
    private Irepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonServicesImplV2(Irepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Create(entity);

        return _converter.Parse(entity);
    }

    public PersonDTO Update(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Update(entity);

        return _converter.Parse(entity);
    }
}
