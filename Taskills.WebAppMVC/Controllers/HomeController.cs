using System.Diagnostics;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskills.WebAppMVC.Models;
using Taskills.WebAppMVC.Models.CosmosDb;
using Taskills.WebAppMVC.Models.CosmosDb.DbModels;

namespace Taskills.WebAppMVC.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await using var context = new ContextCosmosDb();
        var b = (await context.Users.ToListAsync()).Any(u => u.Id.ToString() == userId);
        if (b) return View();

        await context.Users.AddAsync(new User
        {
            Id = new(userId),
            PlacesOfRemembrance = new List<PlaceOfRemembrance>()
        });
        await context.SaveChangesAsync();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> CreateUser()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var user = new User
        {
            Id = userId,
            PlacesOfRemembrance = new List<PlaceOfRemembrance>()
        };
        await using var context = new ContextCosmosDb();
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}