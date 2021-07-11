using Microsoft.EntityFrameworkCore;
using System;
using TimeGraphServer.Models;

namespace TimeGraphServer.DataBase
{
    // A dbcontext instance represents a combination of the unit of work and 
    // repository patterns such that it can query from a databse.

    public class TimeGraphContext : DbContext
    {
        public TimeGraphContext(DbContextOptions<TimeGraphContext> options) : base(options)
        {
            Database.EnsureCreated(); // force Entity Framework Core to create the database containing the seed data
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(new Project
            {
                CreatedBy = "Giorgi",
                Id = 1,
                Name = "Migrate to TLS 1.2"
            }, new Project
            {
                CreatedBy = "Giorgi",
                Id = 2,
                Name = "Move Blog to Hugo"
            });

            modelBuilder.Entity<TimeLog>().HasData(new TimeLog
            {
                Id = 1,
                From = new DateTime(2020, 7, 24, 12, 0, 0),
                To = new DateTime(2020, 7, 24, 14, 0, 0),
                ProjectId = 1,
                User = "Giorgi"
            }, new TimeLog
            {
                Id = 2,
                From = new DateTime(2020, 7, 24, 16, 0, 0),
                To = new DateTime(2020, 7, 24, 18, 0, 0),
                ProjectId = 1,
                User = "Giorgi"
            }, new TimeLog
            {
                Id = 3,
                From = new DateTime(2020, 7, 24, 20, 0, 0),
                To = new DateTime(2020, 7, 24, 22, 0, 0),
                ProjectId = 2,
                User = "Giorgi"
            });
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
    }
}
