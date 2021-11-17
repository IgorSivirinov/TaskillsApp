namespace Taskills.WebApi.Models.Responses;

public class PlaceOfRemembranceResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public PlaceOfRemembranceCoordinate Coordinate { get; set; }
    public IEnumerable<string> Hashtags { get; set; }
    public string UserId { get; set; }
}