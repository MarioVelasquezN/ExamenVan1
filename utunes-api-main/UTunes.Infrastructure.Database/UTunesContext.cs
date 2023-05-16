using Microsoft.EntityFrameworkCore;
using UTunes.Core.Entities;
using UTunes.Infrastructure.Database.DatabaseConfiguration;

namespace UTunes.Infrastructure.Database;
public class UTunesContext : DbContext
{
    public UTunesContext(DbContextOptions<UTunesContext> options)
        : base(options)
    {

    }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Album> Albums { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SongEntityConfiguration());
    }
}

