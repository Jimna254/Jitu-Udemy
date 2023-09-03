using Jitu_Udemy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jitu_Udemy.Data
{

    
    public class AppDbContext:DbContext
    {
       public DbSet<Course> Courses { get; set; }
       public DbSet<User> Users { get; set; }
       public  DbSet<Instructor> Instructors { get; set; }
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
