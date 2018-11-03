using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VuetifySpa.Data.Models;

namespace VuetifySpa.Data.Services
{
 
    public class DbInitializer : IDbInitializer
    {
        private readonly MyDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        readonly ILogger<DbInitializer> _logger;

        public DbInitializer(MyDbContext db, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager,
            ILogger<DbInitializer> logger)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }



        public async Task Initialize()
        {

            _logger.LogWarning("Initialize db");
            await _db.Database.MigrateAsync();



           
            //()=>///этим можно пользоваться///<=()//
            string login = "admin@test.ru";
            string password = "LikeMe123!";
            /////////////////////////////////////////


            if (!_db.Users.Any(x => x.Email.Equals(login)))
            {
                _logger.LogWarning("Initialize data");
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

                _logger.LogWarning("Initialize data save");
                _db.UserRoles.Add(new IdentityUserRole<Guid> { UserId = user.Id, RoleId = role.Id });
                _db.SaveChanges();

            }
        }


    }
}
