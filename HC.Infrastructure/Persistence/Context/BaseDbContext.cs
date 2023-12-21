
using System.Reflection.Metadata;
using HC.Application.Common.Interfaces;
using HC.BE.Infrastructure.Persistence;
using HC.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HC.Infrastructure.Persistence.Context;

public abstract class BaseDbContext : DbContext
{
    protected readonly ICurrentUser _currentUser;
    public readonly DatabaseSettings _databaseSettings;
    protected BaseDbContext(DbContextOptions options, ICurrentUser currentUser, IOptions<DatabaseSettings> databaseSettings) : base(options)
    {
        _currentUser = currentUser;
        _databaseSettings = databaseSettings.Value;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_databaseSettings.ConnectionString).UseSnakeCaseNamingConvention();
        base.OnConfiguring(optionsBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var userId = _currentUser.GetUserId();
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = userId;
                    entry.Entity.LastModifiedBy = userId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = userId;
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedBy = userId;
                    entry.Entity.DeletedOn = DateTime.UtcNow;
                    entry.Entity.IsDeleted = true;
                    break;
            }
        }
        ChangeTracker.DetectChanges();
        return await base.SaveChangesAsync(cancellationToken);
    }

    

    

    

    
}