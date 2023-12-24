using System.Reflection;
using HC.Application.Common.Interfaces;
using HC.Application.Common.Persistence;
using HC.BE.Infrastructure.Persistence;
using HC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HC.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(DbContextOptions options, ICurrentUser currentUser, IOptions<DatabaseSettings> databaseSettings)
        : base(options, currentUser, databaseSettings)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    
}