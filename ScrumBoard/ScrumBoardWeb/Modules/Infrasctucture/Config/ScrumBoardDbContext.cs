namespace ScrumBoardWeb.Modules.Infrasctucture.Config;

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ScrumBoardWeb.Modules.Infrasctucture.Entity;

public class ScrumBoardDbContext : DbContext
{
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public ScrumBoardDbContext(DbContextOptions<ScrumBoardDbContext> options)
        : base(options)
    {
    }

    protected virtual void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
