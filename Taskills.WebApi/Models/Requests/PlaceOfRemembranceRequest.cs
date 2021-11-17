namespace Taskills.WebApi.Models.Requests;

public class PlaceOfRemembranceRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public PlaceOfRemembranceCoordinate Coordinate { get; set; }
    public IEnumerable<string> Hashtags { get; set; }
}