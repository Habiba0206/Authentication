using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Persistence.DataContexts;

public class IdentityDbContext : DbContext
{
    public DbSet<AccessToken> AccessTokens => Set<AccessToken>();
    public DbSet<User> Users => Set<User>();
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}
