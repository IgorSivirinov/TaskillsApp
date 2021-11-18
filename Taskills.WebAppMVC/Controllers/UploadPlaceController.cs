using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Taskills.WebAppMVC.Controllers;

[Authorize]
public class UploadPlaceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
