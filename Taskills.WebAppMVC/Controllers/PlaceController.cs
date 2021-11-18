using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;

namespace Taskills.WebAppMVC.Controllers
{
    public class PlaceController : Controller
    {
        public IActionResult Index(Guid id)
        {
            return View(id);
        }
    }
}
