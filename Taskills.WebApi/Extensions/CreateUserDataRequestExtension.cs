using Taskills.WebApi.Models.CosmosDb.DbModels;
using Taskills.WebApi.Models.Requests;

namespace Taskills.WebApi.Extensions;

public static class CreateUserDataRequestExtension
{
    public static User ToUser(this CreateUserDataRequest createUserData, Guid userId)
        => new()
        {
            Id = userId,
            PlacesOfRemembrance = new List<PlaceOfRemembrance>(),
            PlaceOfRemembranceIds = new List<Guid>()
        };
}