using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    // [HttpGet]
    // public IActionResult GetAll()
    // {
    //     return Ok(new[] {"Ано", "Оно", "Ие"});
    // }
    // [HttpGet("{id}")]
    // public IActionResult GetById(int id)
    // {
    //     return Ok($"User with ID: {id}");
    // }
    [HttpGet("{id?}")]
    public IActionResult GetUser(int? id)
    {
        if (id.HasValue)
        {
            return Ok($"User №{id}");
        }
        else
        {
            return Ok("All users:");
        }
    }
    [HttpPost]
    public IActionResult AddNew([FromBody] string name)
    {
        return Created("api/users/1", $"Created '{name}'");
    }
}