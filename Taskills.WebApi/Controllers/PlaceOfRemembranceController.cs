using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Graph;

using Taskills.WebApi.Extensions;
using Taskills.WebApi.Models.CosmosDb;
using Taskills.WebApi.Models.CosmosDb.DbModels;
using Taskills.WebApi.Models.Requests;
using Taskills.WebApi.Models.Responses;

namespace Taskills.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PlaceOfRemembranceController : ControllerBase
{
    [Route("create/group")]
    [HttpPost]
    public async Task<ActionResult<IEnumerable<IdResponse>>> CreateGroupPlaces(
        IEnumerable<PlaceOfRemembranceRequest> placeOfRemembranceRequestsList)
    {
        var userId = new Guid(User.Claims.First(c => c.Type == "UserId").Value);

        await using var context = new ContextCosmosDb();

        var group = new PlacesGroup();
        await context.PlacesGroups.AddAsync(group);

        var palaces = 
            placeOfRemembranceRequestsList.Select(p => p.ToPlaceOfRemembrance(userId, group.Id));
        await context.PlacesOfRemembrance
            .AddRangeAsync(palaces);

        await context.SaveChangesAsync();

        return Ok(palaces.Select(p => new IdResponse
            {
                Id = p.Id.ToString()
        }));
    }

    [Route("create")]
    [HttpPost]
    public async Task<ActionResult<IdResponse>> CreatePlace(
        PlaceOfRemembranceRequest placeOfRemembranceRequest)
    {
        var userId = new Guid(User.Claims.First(c => c.Type == "UserId").Value);
        var palaces = placeOfRemembranceRequest.ToPlaceOfRemembrance(userId);
        await using var context = new ContextCosmosDb();
        await context.PlacesOfRemembrance
            .AddRangeAsync(palaces);
        await context.SaveChangesAsync();
        return Ok(new IdResponse
        {
            Id = palaces.Id.ToString()
        });
    }

    [Route("getplaces")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlaceOfRemembranceResponse>>> GetPlaces(int skip, int take)
    {
        await using var context = new ContextCosmosDb();
        return Ok(await context.PlacesOfRemembrance.OrderBy(p => p.Name).Skip(skip).Take(take)
            .Select(p => p.ToPlaceOfRemembranceResponse()).ToListAsync());
    }
    [Route("search")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IdResponse>>> SearchPlace(string searchString)
    {
        await using var context = new ContextCosmosDb();
        var placeIds =
            await context.PlacesOfRemembrance.Where(p => 
                p.Name.Contains(searchString) ||
                p.Description.Contains(searchString) ||
                p.Address.Contains(searchString)
            ).Select(p => new IdResponse
            {
                Id = p.Id.ToString()
            }).ToListAsync();
        return Ok(placeIds);
    }
    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<PlaceOfRemembranceResponse>> GetPlace(string id)
    {
        await using var context = new ContextCosmosDb();
        var place = await context.PlacesOfRemembrance.FirstOrDefaultAsync(p => p.Id == new Guid(id));

        if (place == null) return NotFound();
        return Ok(place.ToPlaceOfRemembranceResponse());
    }
}
