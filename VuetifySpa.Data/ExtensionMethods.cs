using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VuetifySpa.Data.Models;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data
{
    public class ExtensionMethods : IExtensionMethods
    {
        private MyDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExtensionMethods(UserManager<ApplicationUser> userManager, MyDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

       




        public ApplicationUser GetUserFromEmail(string email)
        {
            return _db.Users.SingleOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public ApplicationUser GetUserFromAuthLogin(AuthLoginView authLogin)
        {
            return _db.Users.SingleOrDefault(x =>x.Email.Equals(authLogin.Email, StringComparison.OrdinalIgnoreCase));
        }



        /// <summary>
        /// Выдает если ли Admin Роль + маппит
        /// </summary>
        /// <param name="email">email пользователя</param>
        /// <returns></returns>
        public async Task<RegisterUserView> GetUserRegViewFromEmail(string email)
        {
            var user = GetUserFromEmail(email);
            if (user!=null)            {
                var userRegView = user.GetRegisterUser();
                userRegView.IsAdminRole=await _userManager.IsInRoleAsync(user, "Admin");
                return userRegView;
            }
            return null; 

        }

        /// <summary>
        /// Выдает если ли Admin Роль + маппит
        /// </summary>
        /// <param name="email">email пользователя</param>
        /// <returns></returns>
        public async Task<RegisterUserView> GetUserRegViewFromUser(ApplicationUser user)
        {           
            if (user != null)
            {
                var userRegView = user.GetRegisterUser();
                userRegView.IsAdminRole = await _userManager.IsInRoleAsync(user, "Admin");
                return userRegView;
            }
            return null;

        }


    }
}
