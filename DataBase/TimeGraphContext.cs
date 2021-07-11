using Microsoft.EntityFrameworkCore;
using TimeGraphServer.Models;

namespace TimeGraphServer.DataBase
{
    // A dbcontext instance represents a combination of the unit of work and 
    // repository patterns such that it can query from a databse.


    public class TimeGraphContext : DbContext
    {
        public TimeGraphContext(DbContextOptions<TimeGraphContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
    }
}
