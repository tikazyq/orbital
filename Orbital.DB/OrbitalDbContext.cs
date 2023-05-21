using Microsoft.EntityFrameworkCore;
using Orbital.Model;

namespace Orbital.DB;

public class OrbitalDbContext : DbContext
{
    public DbSet<Node> Nodes { get; set; }

    public string DbPath { get; }

    public OrbitalDbContext(DbContextOptions<OrbitalDbContext> options) : base(options)
    {
        DbPath = Utils.GetDefaultDbPath();
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}