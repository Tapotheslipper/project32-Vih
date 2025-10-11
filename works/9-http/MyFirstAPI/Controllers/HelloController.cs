using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers;

[ApiController]
[Route("api/hello")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHello()
    {
        return Ok("Здраво, друже. Моё первый API.");
    }

    [HttpGet("bad")]
    public IActionResult GetBadExample()
    {
        return BadRequest("Ошибка, некорректный запрос.");
    }

    [HttpGet("notfound")]
    public IActionResult GetNotFoundExample()
    {
        return NotFound("Данные не найдены.");
    }
}