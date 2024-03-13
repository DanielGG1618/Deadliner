using Infrastructure.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Persistence;

public class DeadlinerDbContext : IdentityDbContext<DbUser>
{
    public DbSet<DbUser> DbUsers { get; set; } = default!;
    
    public DeadlinerDbContext(DbContextOptions<DeadlinerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeadlinerDbContext).Assembly);

        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}