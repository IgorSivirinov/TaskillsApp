namespace Taskills.WebApi.Models.CosmosDb.DbModels;

public class PlaceOfRemembrance
{
    public  Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public PlaceOfRemembranceCoordinate Coordinate { get; set; }
    public IEnumerable<string> Hashtags { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid? GroupId { get; set; }
    public PlacesGroup? Group { get; set; }
}