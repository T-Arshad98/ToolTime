using Microsoft.EntityFrameworkCore;
using ToolTime.Models;

namespace ToolTime.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tool> Tools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tool>()
                .HasIndex(t => t.SerialNumber)
                .IsUnique();
        }
    }
}
