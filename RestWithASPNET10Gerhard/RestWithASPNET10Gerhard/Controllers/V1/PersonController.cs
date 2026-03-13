using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Gerhard.Data.DTO.V1;
using RestWithASPNET10Gerhard.Model;
using RestWithASPNET10Gerhard.Services;

namespace RestWithASPNET10Gerhard.Controllers.V1;

[ApiController]
[Route("api/[controller]/v1")]
public class PersonController : ControllerBase
{
    private IPersonServices _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(
        IPersonServices personService,
        ILogger<PersonController> logger
        )
    {
        _personService = personService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Fetching all people");

        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        _logger.LogInformation("Fetching person with ID: {Id}", id);

        var person = _personService.FindById(id);

        if (person == null)
        {
            _logger.LogWarning("Person with ID {id} not found", id);

            return NotFound();
        }

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PersonDTO person)
    {
        _logger.LogInformation("Creating a new person: {firstName}", person.FirstName);

        var createdPerson = _personService.Create(person);

        if (createdPerson == null)
        {
            _logger.LogError("Failed to create person with name {firstName}", person.FirstName);

            return NotFound();
        }

        return Ok(person);
    }

    [HttpPut]
    public IActionResult Put([FromBody] PersonDTO person)
    {
        _logger.LogInformation("Updating person with ID {id}", person.Id);

        var createdPerson = _personService.Update(person);
        if (createdPerson == null)
        {
            _logger.LogError("Failed to update person with ID {id}", person.Id);
            return NotFound();
        }
        _logger.LogDebug("Person updated successfully: {firstName}", createdPerson.FirstName);
        return Ok(createdPerson);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Deleting person with ID {id}", id);

        _personService.Delete(id);

        _logger.LogInformation("Person with ID {id} deleted successfully", id);

        return NoContent();
    }
}
