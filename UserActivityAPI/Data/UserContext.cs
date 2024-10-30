using Microsoft.EntityFrameworkCore;
using UserActivityAPI.Models;

namespace UserActivityAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Seed data for Role table
            //modelBuilder.Entity<Role>().HasData(
            //    new Role { RoleId = 1, RoleName = "Admin" },
            //    new Role { RoleId = 2, RoleName = "User" },
            //    new Role { RoleId = 3, RoleName = "Moderator" }
            //);

            // Seed data for Status table
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "Active" },
                new Status { StatusId = 2, StatusName = "Inactive" },
                new Status { StatusId = 3, StatusName = "Banned" }
            );
        }

    }
}
