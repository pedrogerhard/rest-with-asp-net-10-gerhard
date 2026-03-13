using Mapster;
using RestWithASPNET10Gerhard.Data.DTO.V1;
using RestWithASPNET10Gerhard.Model;
using RestWithASPNET10Gerhard.Repositories;

namespace RestWithASPNET10Gerhard.Services.Impl;

public class PersonServicesImpl : IPersonServices
{
    private Irepository<Person> _repository;

    public PersonServicesImpl(Irepository<Person> repository)
    {
        _repository = repository;
    }

    public List<PersonDTO> FindAll()
    {
        return _repository.FindAll().Adapt<List<PersonDTO>>();
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = person.Adapt<Person>();

        entity = _repository.Create(entity);

        return entity.Adapt<PersonDTO>();
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }

    public PersonDTO FindById(long id)
    {

        return _repository.FindById(id).Adapt<PersonDTO>();
    }

    public PersonDTO Update(PersonDTO person)
    {
        var entity = person.Adapt<Person>();

        entity = _repository.Update(entity);

        return entity.Adapt<PersonDTO>();
    }
}
