using RestWithASPNET10Gerhard.Data.Converter.Contract;
using RestWithASPNET10Gerhard.Data.DTO;
using RestWithASPNET10Gerhard.Model;

namespace RestWithASPNET10Gerhard.Data.Converter.Impl;

public class PersonConverter : IParser<PersonDTO, Person>, IParser<Person, PersonDTO>
{
    public Person Parse(PersonDTO origin)
    {
        if (origin == null) return null;

        return new Person
        {
            Id = origin.Id,
            FirstName = origin.FirstName,
            LastName = origin.LastName,
            Address = origin.Address,
            Gender = origin.Gender,
        };
    }

    public PersonDTO Parse(Person origin)
    {
        if (origin == null) return null;

        return new PersonDTO
        {
            Id = origin.Id,
            FirstName = origin.FirstName,
            LastName = origin.LastName,
            Address = origin.Address,
            Gender = origin.Gender,
        };
    }

    public List<Person> ParseList(List<PersonDTO> origin)
    {
        if (origin == null) return null;

        return [.. origin.Select(item => Parse(item))];
    }

    public List<PersonDTO> ParseList(List<Person> origin)
    {
        if (origin == null) return null;

        return [.. origin.Select(item => Parse(item))];
    }
}
