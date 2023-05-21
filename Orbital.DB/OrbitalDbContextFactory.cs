using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Orbital.DB;

public class OrbitalDbContextFactory : IDesignTimeDbContextFactory<OrbitalDbContext>
{
    public OrbitalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrbitalDbContext>();
        optionsBuilder.UseSqlite($"Data Source={Utils.GetDefaultDbPath()}");

        return new OrbitalDbContext(optionsBuilder.Options);
    }
}