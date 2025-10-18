using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHello()
    {
        return Ok("Это привет.");
    }
    [HttpGet("time")]
    public IActionResult GetTime()
    {
        return Ok($"Время сейчас: {DateTime.Now}");
    }
    [HttpGet("summ")]
    public IActionResult GetSumm([FromQuery] int num1, [FromQuery] int num2)
    {
        int num3 = num1 + num2;
        return Ok($"Вот сумма: {num3}");
    }
}