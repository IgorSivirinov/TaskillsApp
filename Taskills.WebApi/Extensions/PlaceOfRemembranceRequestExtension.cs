using Taskills.WebApi.Models.CosmosDb.DbModels;
using Taskills.WebApi.Models.Requests;

namespace Taskills.WebApi.Extensions;

public static class PlaceOfRemembranceRequestExtension
{
    public static PlaceOfRemembrance ToPlaceOfRemembrance(this PlaceOfRemembranceRequest request, Guid userId) 
        => new() {
                    Id = new(request.Id),
                    Name = request.Name,
                    Address = request.Address,
                    Coordinate = request.Coordinate,
                    Description = request.Description,
                    Hashtags = request.Hashtags,
                    UserId = userId
                };
    public static PlaceOfRemembrance ToPlaceOfRemembrance(this PlaceOfRemembranceRequest request, Guid userId, Guid groupId)
        => new()
        {
            Id = new(request.Id),
            Name = request.Name,
            Address = request.Address,
            Coordinate = request.Coordinate,
            Description = request.Description,
            Hashtags = request.Hashtags,
            UserId = userId,
            GroupId = groupId
        };
}