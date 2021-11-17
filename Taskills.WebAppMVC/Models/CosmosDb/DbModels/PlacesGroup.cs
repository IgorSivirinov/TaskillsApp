namespace Taskills.WebAppMVC.Models.CosmosDb.DbModels;

public class PlacesGroup
{
    public Guid Id { get; set; }
    public IEnumerable<Guid> PlaceOfRemembranceIds { get; set; }
    public IEnumerable<PlaceOfRemembrance> PlacesOfRemembrance { get; set; }
}