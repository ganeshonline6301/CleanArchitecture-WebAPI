using System.Reflection;
using CleanArch.Domain.Todos;
using CleanArch.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Common;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}