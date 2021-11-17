using Taskills.WebApi.Models.CosmosDb.DbModels;
using Taskills.WebApi.Models.Responses;

namespace Taskills.WebApi.Extensions;

public static class PlaceOfRemembranceExtension
{
    public static PlaceOfRemembranceResponse ToPlaceOfRemembranceResponse(this PlaceOfRemembrance placeOfRemembrance)
        => new()
        {
            Id = placeOfRemembrance.Id.ToString(),
            Name = placeOfRemembrance.Name,
            Description = placeOfRemembrance.Description,
            Address = placeOfRemembrance.Address,
            Coordinate = placeOfRemembrance.Coordinate,
            Hashtags = placeOfRemembrance.Hashtags,
            UserId = placeOfRemembrance.UserId.ToString()
        };
}