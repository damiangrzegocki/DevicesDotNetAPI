using JobInterviewTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace JobInterviewTask.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Device>().ToTable("Devices");
            builder.Entity<Device>().HasKey(p => p.Id);
            builder.Entity<Device>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Device>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Device>().Property(p => p.Description).HasMaxLength(200);
            builder.Entity<Device>().Property(p => p.Disabled).IsRequired();

            builder.Entity<Device>().HasData
            (
                new Device { Id = Guid.NewGuid(), Name = "Canon", Description = "Camera", Disabled = true },
                new Device { Id = Guid.NewGuid(), Name = "Nikon", Description = "Camera", Disabled = true },
                new Device { Id = Guid.NewGuid(), Name = "HP", Description = "Notebook", Disabled = false },
                new Device { Id = Guid.NewGuid(), Name = "Dell", Description = "PC", Disabled = false }
            );
        }
    }
}
