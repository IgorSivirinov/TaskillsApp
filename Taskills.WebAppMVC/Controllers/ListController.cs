using Microsoft.AspNetCore.Mvc;

namespace Taskills.WebAppMVC.Controllers;
public class ListController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
