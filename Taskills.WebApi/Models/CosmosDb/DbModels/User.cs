namespace Taskills.WebApi.Models.CosmosDb.DbModels;

public class User
{
    public Guid Id { get; set; }

    public IEnumerable<Guid> PlaceOfRemembranceIds { get; set; }
    public IEnumerable<PlaceOfRemembrance> PlacesOfRemembrance { get; set; }
}