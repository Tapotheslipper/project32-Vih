using Microsoft.AspNetCore.Mvc;

public class HomeyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
}
