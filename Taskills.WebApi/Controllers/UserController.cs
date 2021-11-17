using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskills.WebApi.Models.CosmosDb;
using Taskills.WebApi.Models.CosmosDb.DbModels;
using Taskills.WebApi.Models.Responses;

namespace Taskills.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [Route("create")]
    [HttpGet]
    public async Task<ActionResult<IdResponse>> CreateUser()
    {
        var userId = new Guid(User.Claims.First(c => c.Type == "UserId").Value);
        var user = new User
        {
            Id = userId,
            PlaceOfRemembranceIds = new List<Guid>(),
            PlacesOfRemembrance = new List<PlaceOfRemembrance>()
        };
        await using var context = new ContextCosmosDb();
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return Ok(user.Id.ToString());
    }

    [Route("{userId}")]
    [HttpGet]
    public async Task<ActionResult<UserDataResponse>> GetUserData(string userId)
    {
        await using var context = new ContextCosmosDb();
        try
        {
            var account = await AppConfig.GraphClient.Users[userId].Request().Select(user => new
            {
                user.GivenName,
                user.Mail
            }).GetAsync();

            return Ok(new UserDataResponse
            {
                Id = userId,
                Email = account.Mail,
                Login = account.GivenName
            });
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    [Route("{userId}/palaceofremembranceids")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IdResponse>>> GetPlaceOfRemembranceIds(string userId)
    {
        await using var context = new ContextCosmosDb();
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
        if (user == null) return NotFound();
        return Ok(user.PlaceOfRemembranceIds.Select(p => p.ToString()));
    }
}