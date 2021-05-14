using Microsoft.EntityFrameworkCore;

namespace CourseApplication.Models
{
    public class CourseApplicationContext : DbContext
    {
        public CourseApplicationContext(
            DbContextOptions<CourseApplicationContext> options
        ) : base(options) {}

        public DbSet<CourseApplicationItem> CourseApplications { get; set; }
    }
}
