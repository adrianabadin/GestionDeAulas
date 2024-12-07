using Microsoft.AspNetCore.Identity;
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
        //public DbSet<User> Users { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<ClassRoom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Institutions> Institutions { get; set; }
        public DbSet<Reserve> Reserves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasMany<IdentityUserRole<string>>(u => u.MyUserRoles).WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            builder.Entity<Roles>().HasMany<IdentityUserRole<string>>(u => u.UserRoles).WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            builder.Entity<ClassRoom>().HasAlternateKey(e=>e.Id);
        }

    }
}
