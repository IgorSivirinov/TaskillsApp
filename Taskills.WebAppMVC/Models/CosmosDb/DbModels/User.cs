namespace Taskills.WebAppMVC.Models.CosmosDb.DbModels;

public class User
{
    public Guid Id { get; set; }

    // public ICollection<Guid> PlaceOfRemembranceIds { get; set; }
    public IEnumerable<PlaceOfRemembrance> PlacesOfRemembrance { get; set; }
}