using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskills.WebAppMVC.Extensions;
using Taskills.WebAppMVC.Models.CosmosDb;

namespace Taskills.WebAppMVC.Controllers;

[Authorize]
public class PlaceController : Controller
{
    public async Task<IActionResult> Index(Guid id)
    {
        await using var context = new ContextCosmosDb();
        var place = await context.PlacesOfRemembrance.Where(p => p.Id == id).FirstOrDefaultAsync();
        return View(place.ToPlace());
    }
}