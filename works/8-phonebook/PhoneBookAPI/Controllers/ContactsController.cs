using Microsoft.AspNetCore.Mvc;

[Route("api/phonebook")]
[ApiController]
public class ContactsController : ControllerBase
{
    // fields
    private readonly Dictionary<string, Contact> _contacts;

    // constructor
    public ContactsController()
    {
        _contacts = new Dictionary<string, Contact>
        {
            {"personalPlaceholder", new PersonalContact("nameP", "123")},
            {"businessPlaceholder", new BusinessContact("nameB", "456")}
        };
    }

    // methods
    [HttpGet]
    public IActionResult GetAll()
    {
        var contacts = _contacts;
        return Ok(contacts);
    }
    [HttpGet("{key}")]
    public IActionResult GetOne(string key) {
        if (_contacts.ContainsKey(key))
        {
            var contact = _contacts[key];
            return Ok(contact);
        }
        return NotFound();
    }
    [HttpPost("personal")]
    public IActionResult AddPersonal([FromBody] PersonalContact c)
    {
        if (_contacts.ContainsKey(c.PhoneNum))
        {
            return BadRequest("Данный номер уже существует.");
        }
        _contacts.Add(c.PhoneNum, c);
        return NoContent();
    }
    [HttpPost("business")]
    public IActionResult AddBusiness([FromBody] BusinessContact c)
    {
        if (_contacts.ContainsKey(c.PhoneNum))
        {
            return BadRequest("Данный номер уже существует.");
        }
        _contacts.Add(c.PhoneNum, c);
        return NoContent();
    }
}