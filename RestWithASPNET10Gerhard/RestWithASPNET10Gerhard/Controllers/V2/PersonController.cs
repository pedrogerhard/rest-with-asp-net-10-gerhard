using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Gerhard.Data.DTO.V2;
using RestWithASPNET10Gerhard.Services.Impl;

namespace RestWithASPNET10Gerhard.Controllers.V2;

[ApiController]
[Route("api/[controller]/V2")]
public class PersonController : ControllerBase
{
    private PersonServicesImplV2 _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(
        PersonServicesImplV2 personService,
        ILogger<PersonController> logger
        )
    {
        _personService = personService;
        _logger = logger;
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
}
