using Microsoft.AspNetCore.Mvc;

[Route("api/phonebook")]
[ApiController]
public class ContactController : ControllerBase
{
    // fields
    private readonly ContactService _contactService;
    
    // constructor
    public ContactController(ContactService contactService)
    {
        _contactService = contactService;
    }

    // methods
    [HttpGet]
    public ActionResult<IEnumerable<string>> GetAll()
    {
        var contacts = _contactService.GetAllContacts();
        return Ok(contacts);
    }
    // [HttpGet]
    // public ActionResult GetOne(int id) {
    //     var contact = _contactService.GetContactById(id);
    //     return Ok(contact);
    // }
    [HttpPost("personal")]
    public ActionResult AddPersonal([FromBody] PersonalContact newC)
    {
        _contactService.AddContact(newC);
        return CreatedAtAction(nameof(GetAll), new { }, newC);
    }
    [HttpPost("business")]
    public ActionResult AddBusiness([FromBody] BusinessContact newC)
    {
        _contactService.AddContact(newC);
        return CreatedAtAction(nameof(GetAll), new { }, newC);
    }
    // [HttpPut]
    // public ActionResult UpdateContact()
    [HttpDelete("{id}")]
    public ActionResult DeleteContact(int id)
    {
        _contactService.DeleteContact(id);
        return NoContent();
    }
}