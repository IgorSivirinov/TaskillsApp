using Taskills.WebAppMVC.Models;
using Taskills.WebAppMVC.Models.CosmosDb.DbModels;

namespace Taskills.WebAppMVC.Extensions;

public static class PlaceOfRemembranceExtension
{
    public static Place ToPlace(this PlaceOfRemembrance place)
        => new()
        {
            Name = place.Name,
            Address = place.Address,
            Description = place.Description
        };
    public static PlaceListItem ToPlaceListItem(this PlaceOfRemembrance place)
        => new()
        {
            Id = place.Id,
            Name = place.Name,
            Address = place.Address,
            Description = place.Description,
            TagsString = string.Join("", place.Hashtags.Select(s => $"#{s.Tag} "))
        };
}