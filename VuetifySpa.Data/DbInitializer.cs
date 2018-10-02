using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VuetifySpa.Data.Models;

namespace VuetifySpa.Data
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
    public class DbInitializer : IDbInitializer
    {
        private readonly MyDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public DbInitializer(MyDbContext db, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }



        public async Task Initialize()
        {            
       

            string login = "admin@test.ru";
            string password = "LikeMe123!";

            if (!_db.Users.Any(x => x.Email.Equals(login))) { 

                var user = new ApplicationUser()
                {
                    UserName = login,
                    Email = login,
                    FirstName = "Ivan",
                    LastName = "Ivanov"
                };

                var role = new ApplicationRole()
                {
                    Name = "Admin",
                    Description = "Admin"
                };

                await _userManager.CreateAsync(user, password);
                await _roleManager.CreateAsync(role);

                _db.UserRoles.Add(new IdentityUserRole<Guid> { UserId = user.Id, RoleId = role.Id });
                _db.SaveChanges();

            }
        }


    }
}
