using RestWithASPNET10Gerhard.Model;
using RestWithASPNET10Gerhard.Repositories;

namespace RestWithASPNET10Gerhard.Services.Impl;

public class PersonServicesImpl : IPersonServices
{
    private IPersonRepository _repository;

    public PersonServicesImpl(IPersonRepository repository)
    {
        _repository = repository;
    }

    public List<Person> FindAll()
    {

        return _repository.FindAll();
    }

    public Person Create(Person person)
    {
        return _repository.Create(person);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }

    public Person FindById(long id)
    {

        return _repository.FindById(id);
    }

    public Person Update(Person person)
    {
        return _repository.Update(person);
    }
}
