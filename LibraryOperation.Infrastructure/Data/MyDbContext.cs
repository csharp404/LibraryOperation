

using LibraryOperation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryOperation.Infrastructure.Data;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{

    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}