using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskills.WebAppMVC.Models.CosmosDb;
using Taskills.WebAppMVC.Models.Items;

namespace Taskills.WebAppMVC.Controllers;

[Authorize]
public class PlaceListController : Controller
{
    public async Task<IActionResult> Index()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await using var context = new ContextCosmosDb();
        var places = await context.PlacesOfRemembrance.Where(p => p.UserId == userId)
            .Select(i => new PlaceItem()
            {
                Id = i.PlaceOfRemembranceId,
                Adress = i.Address,
                Name = i.Name
            }).ToListAsync();
        return View(places);
    }

    public async Task<IActionResult> ToPlace(Guid id)
    {
        await using var context = new ContextCosmosDb();

        return RedirectToAction("Index", "Place");
    }
}