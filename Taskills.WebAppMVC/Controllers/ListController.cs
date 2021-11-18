using System.Numerics;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskills.WebAppMVC.Extensions;
using Taskills.WebAppMVC.Models;
using Taskills.WebAppMVC.Models.CosmosDb;

namespace Taskills.WebAppMVC.Controllers;

[Authorize]
public class ListController : Controller
{
    public async Task<IActionResult> Index(List<PlaceListItem> placeList)
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await using var context = new ContextCosmosDb();
        var places = await context.PlacesOfRemembrance.Where(p => p.UserId == userId)
            .Select(p => p.ToPlaceListItem()).ToListAsync();
        return View(places);
    }

    public async Task<IActionResult> SearchIndex(string searchString)
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await using var context = new ContextCosmosDb();
        var places = await context.PlacesOfRemembrance
            .Where(p => p.UserId == userId)
            .Where(p =>
                p.Name.Contains(searchString) ||
                p.Description.Contains(searchString) ||
                p.Address.Contains(searchString)
            )
            .Select(p => p.ToPlaceListItem()).ToListAsync();
        return RedirectToAction("Index", new {places});
    }

    public async Task<IActionResult> AllItemsIndex()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await using var context = new ContextCosmosDb();
        var places = await context.PlacesOfRemembrance.Where(p => p.UserId == userId)
            .Select(p => p.ToPlaceListItem()).ToListAsync();
        return RedirectToAction("Index", "List", new{ placeList = places});
    }
}
