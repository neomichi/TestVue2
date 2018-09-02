using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VuetifySpa.Data.Models;


namespace VuetifySpa.Data
{


    public class MyDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Int64> 
       
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        
        }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id=1,Email="admin@test.ru", FirstName = "Иван", LastName="Иванов" });


            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<ApplicationRole>().ToTable("Roles");

            builder.Entity<ApplicationUserRole>().ToTable("UserRoles");

            builder.Entity<ApplicationRoleClaim>().ToTable("RoleClaims");

            builder.Entity<ApplicationUserClaim>().ToTable("UserClaims");

            builder.Entity<ApplicationUserLogin>().ToTable("UserLogins");

            builder.Entity<ApplicationUserToken>().ToTable("UserTokens");
        }
    }
}
