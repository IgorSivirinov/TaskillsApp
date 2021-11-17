using Microsoft.EntityFrameworkCore;
using Taskills.WebApi.Models.CosmosDb.DbModels;

namespace Taskills.WebApi.Models.CosmosDb;

public class ContextCosmosDb: DbContext
{
    public DbSet<PlaceOfRemembrance> PlacesOfRemembrance { get; set; }
    public DbSet<PlacesGroup> PlacesGroups { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            @"https://azure-sql.documents.azure.com:443/",
            @"sDVtSg7iXJxHk87tUg997Ux4Fd5fBkAFjfULMw7SaBBzfSiCrehUADfdJxkbSlyzSvHqLf7XFIvtaIblvMrAYQ==",
            @"Taskills");
        Database.EnsureCreated();
    }
}