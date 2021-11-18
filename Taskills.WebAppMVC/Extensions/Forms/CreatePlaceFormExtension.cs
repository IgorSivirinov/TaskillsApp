using Taskills.WebAppMVC.Models.CosmosDb.DbModels;
using Taskills.WebAppMVC.Models.Forms;

namespace Taskills.WebAppMVC.Extensions.Forms
{
    public static class CreatePlaceFormExtension
    {
        public static PlaceOfRemembrance ToPlaceOfRemembrance(this CreatePlaceForm form, Guid userId) =>
            new()
            {
                Name = form.Name,
                Address = form.Adress,
                Coordinate = new()
                {
                    Lat = 1,
                    Lng = 1
                },
                Description = form.Description,
                Hashtags = form.Hashtags.Split(' ').Select(t => new HashTag(){Tag = t}).ToHashSet(),
                UserId = userId
            };
        
    }
}
