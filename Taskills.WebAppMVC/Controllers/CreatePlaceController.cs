using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskills.WebAppMVC.Extensions.Forms;
using Taskills.WebAppMVC.Models.CosmosDb;
using Taskills.WebAppMVC.Models.Forms;

namespace Taskills.WebAppMVC.Controllers;

[Authorize]
public class CreatePlaceController : Controller
{
    public IActionResult CreatePlaceForm()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlaceForm(CreatePlaceForm form)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var palaces = form.ToPlaceOfRemembrance(new(userId));
        await using var context = new ContextCosmosDb();
        await context.PlacesOfRemembrance
            .AddRangeAsync(palaces);
        await context.SaveChangesAsync();
        return RedirectToAction("AllItemsIndex", "List");
    }
}