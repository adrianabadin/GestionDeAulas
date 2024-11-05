using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static GestionDeAulas.Models.User;

namespace GestionDeAulas.Models
{
    public class AppDbContext :IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<ClassRoom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Institutions> Institutions { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        

    }
}
