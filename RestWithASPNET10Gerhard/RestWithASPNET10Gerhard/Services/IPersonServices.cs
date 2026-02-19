using RestWithASPNET10Gerhard.Model;

namespace RestWithASPNET10Gerhard.Services;

public interface IPersonServices
{
    Person Create(Person person);

    Person FindById(long id);

    List<Person> FindAll();

    Person Update(Person person);

    void Delete(long id);
}
