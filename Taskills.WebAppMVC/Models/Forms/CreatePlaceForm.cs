namespace Taskills.WebAppMVC.Models.Forms
{
    public class CreatePlaceForm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public PlaceOfRemembranceCoordinate Coordinate { get; set; }
        public string Hashtags { get; set; }
    }
}
