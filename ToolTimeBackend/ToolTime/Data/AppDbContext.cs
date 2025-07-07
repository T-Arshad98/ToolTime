using Microsoft.EntityFrameworkCore;
using ToolTime.Models;

namespace ToolTime.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tool> Tools { get; set; }

        public DbSet<CheckoutRecord> CheckoutRecords { get; set; }

        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Seed Tools
            modelBuilder.Entity<Tool>().HasData(
                new Tool { Id = 1, Name = "Makita Hammer Drill", SerialNumber = "SN12345", Type = "Drill", LastInspectionDate = DateTime.UtcNow.AddDays(-10) },
                new Tool { Id = 2, Name = "Bosch Circular Saw", SerialNumber = "SN98765", Type = "Saw", LastInspectionDate = DateTime.UtcNow.AddDays(-5) }
            );

            // Seed CheckoutRecords
            modelBuilder.Entity<CheckoutRecord>().HasData(
                new CheckoutRecord
                {
                    Id = 1,
                    ToolId = 1,
                    UserId = "johndoe123",
                    CheckoutDateTime = DateTime.UtcNow.AddDays(-2),
                    ExpectedReturnDateTime = DateTime.UtcNow.AddDays(5),
                    ActualReturn = null
                }
            );

            // Sample Maintenance Requests
            modelBuilder.Entity<MaintenanceRequest>().HasData(
                new MaintenanceRequest
                {
                    Id = 1,
                    ToolId = 1,
                    UserId = "johndoe123",
                    IssueDesc = "Battery not charging properly",
                    Status = "Open",
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    ResolvedAt = null
                },
                new MaintenanceRequest
                {
                    Id = 2,
                    ToolId = 2,
                    UserId = "johndoe123",
                    IssueDesc = "Blade guard is loose",
                    Status = "Resolved",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    ResolvedAt = DateTime.UtcNow.AddDays(-5)
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = "u1", Username = "admin", Password = "admin123" },
                new User { Id = "u2", Username = "manager", Password = "manager123" },
                new User { Id = "u3", Username = "tech1", Password = "tech123" },
                new User { Id = "u4", Username = "tech2", Password = "tech123" },
                new User { Id = "u5", Username = "user1", Password = "user123" },
                new User { Id = "u6", Username = "user2", Password = "user123" },
                new User { Id = "u7", Username = "user3", Password = "user123" },
                new User { Id = "u8", Username = "john", Password = "john123" },
                new User { Id = "u9", Username = "jane", Password = "jane123" },
                new User { Id = "u10", Username = "dev", Password = "dev123" },
                new User { Id = "u11", Username = "qa", Password = "qa123" },
                new User { Id = "u12", Username = "viewer", Password = "view123" },
                new User { Id = "u13", Username = "superadmin", Password = "super123" },
                new User { Id = "u14", Username = "readonly", Password = "readonly123" },
                new User { Id = "u15", Username = "hybriduser", Password = "hybrid123" }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = "u1", RoleName = "Admin" },
                new UserRole { UserId = "u2", RoleName = "Manager" },
                new UserRole { UserId = "u3", RoleName = "Technician" },
                new UserRole { UserId = "u4", RoleName = "Technician" },
                new UserRole { UserId = "u5", RoleName = "User" },
                new UserRole { UserId = "u6", RoleName = "User" },
                new UserRole { UserId = "u7", RoleName = "User" },
                new UserRole { UserId = "u8", RoleName = "Technician" },
                new UserRole { UserId = "u8", RoleName = "User" },
                new UserRole { UserId = "u9", RoleName = "Manager" },
                new UserRole { UserId = "u9", RoleName = "User" },
                new UserRole { UserId = "u10", RoleName = "Developer" },
                new UserRole { UserId = "u10", RoleName = "Admin" },
                new UserRole { UserId = "u11", RoleName = "QA" },
                new UserRole { UserId = "u12", RoleName = "Viewer" },
                new UserRole { UserId = "u13", RoleName = "Admin" },
                new UserRole { UserId = "u13", RoleName = "Manager" },
                new UserRole { UserId = "u13", RoleName = "Technician" },
                new UserRole { UserId = "u14", RoleName = "ReadOnly" },
                new UserRole { UserId = "u15", RoleName = "User" },
                new UserRole { UserId = "u15", RoleName = "Manager" }
            );

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleName }); // 👈 Composite PK

            // Optional: Relationship setup (optional if using EF conventions)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<Tool>()
                .HasIndex(t => t.SerialNumber)
                .IsUnique();
        }
    }
}
