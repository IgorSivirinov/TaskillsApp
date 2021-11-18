using System.IO;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

using Taskills.WebAppMVC.Extensions.Forms;
using Taskills.WebAppMVC.Models.CosmosDb;
using Taskills.WebAppMVC.Models.CosmosDb.DbModels;
using Taskills.WebAppMVC.Models.Forms;

namespace Taskills.WebAppMVC.Controllers
{
    [Authorize]
    public class CreatePlaceController : Controller
    {
        IWebHostEnvironment _appEnvironment;
        public CreatePlaceController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
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

            if (form.File != null)
            {
                string path = "./Files/" + form.File.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                await using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await form.File.CopyToAsync(fileStream);
                }

                palaces.CosmosImage = path;
            }

            await context.PlacesOfRemembrance
                .AddAsync(palaces);
            await context.SaveChangesAsync();
            return RedirectToAction("CreatePlaceForm");
        }

    }
}
