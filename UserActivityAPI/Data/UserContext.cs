using Microsoft.EntityFrameworkCore; 
using UserActivityAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UserActivityAPI.Data
{
    public class UserContext : IdentityDbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             

            // Seed data for Status table
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "Active" },
                new Status { StatusId = 2, StatusName = "Inactive" },
                new Status { StatusId = 3, StatusName = "Banned" }
            );
        }

    }
}
