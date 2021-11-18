using Microsoft.EntityFrameworkCore;
using Taskills.WebAppMVC.Models.CosmosDb.DbModels;

namespace Taskills.WebAppMVC.Models.CosmosDb;

public class ContextCosmosDb: DbContext
{
    public DbSet<PlaceOfRemembrance> PlacesOfRemembrance { get; set; }
    // public DbSet<PlacesGroup> PlacesGroups { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            @"https://azure-sql.documents.azure.com:443/",
            @"sDVtSg7iXJxHk87tUg997Ux4Fd5fBkAFjfULMw7SaBBzfSiCrehUADfdJxkbSlyzSvHqLf7XFIvtaIblvMrAYQ==",
            @"Taskills");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<User>()
        //     .ToContainer("Users")
        //     .HasMany(u => u.PlacesOfRemembrance);
        // modelBuilder.Entity<PlaceOfRemembrance>()
        //     .ToContainer("PlacesOfRemembrance");

    }
}