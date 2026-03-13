using RestWithASPNET10Gerhard.Data.DTO.V1;
using RestWithASPNET10Gerhard.Model;

namespace RestWithASPNET10Gerhard.Services;

public interface IPersonServices
{
    PersonDTO Create(PersonDTO person);

    PersonDTO FindById(long id);

    List<PersonDTO> FindAll();

    PersonDTO Update(PersonDTO person);

    void Delete(long id);
}
