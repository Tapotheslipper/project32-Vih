using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers;

[ApiController]
[Route("api/info")]
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
    public IActionResult GetSumm([FromQuery] int? num1, [FromQuery] int? num2)
    {
        if (!num1.HasValue || !num2.HasValue)
        {
            return BadRequest("Оба параметра должны присутствовать.");
        }
        int num3 = num1.Value + num2.Value;
        var res = new { num1 = num1, num2 = num2, sum = num3};
        return Ok(res);
    }
    [HttpGet("echo")]
    public IActionResult GetEcho([FromQuery] string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return BadRequest("text пустой, либо отсутствует.");
        }
        var echo = new { echo = text };
        return Ok(echo);
    }
    [HttpGet("now")]
    public IActionResult GetNow()
    {
        DateTime timeNow = DateTime.Now;
        var res = new { now = timeNow };
        return Ok(res);
    }
}