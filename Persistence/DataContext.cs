using Microsoft.EntityFrameworkCore;
namespace Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Domain.Tasks> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Tasks>()
            .HasMany(t => t.SubTasks)
            .WithOne()
            .HasForeignKey(t => t.ParentId);
    }
}
