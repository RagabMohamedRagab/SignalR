using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Notifcations.Utlties.Configurtions;

namespace Notifcations.Models {
    public class AppDbContext:IdentityDbContext<IdentityUser> {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().HasData(
                 new IdentityUser()
                 {
                     Email = "Admin123@gamil.com",
                     UserName= "Admin123@gamil.com",
                     PasswordHash = "Admin123",
                     EmailConfirmed = true,
                     LockoutEnabled = true,
                 }
                );
            builder.Entity<IdentityRole>().HasData(
                 new IdentityRole
                 {
                     Name="Admin"
                 },
                 new IdentityRole
                 {
                     Name = "User"
                 }
                );

         

        }
    }
}
