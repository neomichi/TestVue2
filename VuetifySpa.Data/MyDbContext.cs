using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VuetifySpa.Data.Models;


namespace VuetifySpa.Data
{
    


    public class MyDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>

    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
           

        }
               

       
          





    protected override void OnModelCreating(ModelBuilder builder)
        {
            //var roleGuid = Guid.NewGuid();
            //var userGuid = Guid.NewGuid();
            
            
            //builder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole { Id = roleGuid, Name = "Admin", Description = "Administrator" });
            ////builder.Entity<ApplicationUser>().HasData(
            ////     new ApplicationUser { Id = userGuid, Email = "admin@test.ru", FirstName = "Иван", LastName = "Иванов", UserName = "admin@test.ru",p });

            ////builder.Entity<ApplicationUserRole>().HasData(
            ////new ApplicationUserRole { RoleId=roleGuid,UserId=userGuid });


            

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<ApplicationRole>().ToTable("Roles");
           
        }
    }
}
