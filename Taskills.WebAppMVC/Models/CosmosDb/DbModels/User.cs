namespace Taskills.WebAppMVC.Models.CosmosDb.DbModels;

public class User
{
    public Guid UserId { get; set; }

    public IEnumerable<PlaceOfRemembrance> PlacesOfRemembrance { get; set; }
}