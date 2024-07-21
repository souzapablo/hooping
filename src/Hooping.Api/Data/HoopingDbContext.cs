using Hooping.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hooping.Api.Data;

public class HoopingDbContext(
    DbContextOptions<HoopingDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
