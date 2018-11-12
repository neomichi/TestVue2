using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using VuetifySpa.Data.Models;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Services
{
    public class UserService : IUserService
    {
        private MyDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnviroment;

        public UserService(UserManager<ApplicationUser> userManager, MyDbContext db, IHostingEnvironment hostingEnviroment)
        {
            _userManager = userManager;
            _db = db;
            _hostingEnviroment = hostingEnviroment;
        }


        public async Task<UserView>  UpdateUser(UserView userView)
        {
            userView.Avatar = Code.SaveImage64(userView.Id, 
                userView.AvatarUrl, userView.ImgType, _hostingEnviroment.WebRootPath, "avatar");
       
            var user = _db.Users.SingleOrDefault(x => x.Id == userView.Id);
            if (user != null)
            {
                user.FirstName = userView.FirstName;
                user.LastName = userView.LastName;
                user.Avatar = userView.Avatar;
                _db.Update(user);
                _db.SaveChanges();
                
            }
            return await GetUserViewFromUser(user);
        }

        
       

        public ApplicationUser GetUserFromAuthLogin(AuthLoginView authLogin)
        {
            return _db.Users.SingleOrDefault(x => x.Email.Equals(authLogin.Email, StringComparison.OrdinalIgnoreCase));
        }



        /// <summary>
        /// Выдает UserView
        /// </summary>
        /// <param name="email">email пользователя</param>
        /// <returns></returns>
        public async Task<UserView> GetUserViewFromEmail(string email)
        {
            return await GetUserViewFromUser(await _userManager.FindByEmailAsync(email));
        }
        /// <summary>
        /// Выдает UserView
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserView> GetUserViewFromUser(ApplicationUser user)
        {         
            if (user != null)
            {
                var userview = UserToUserView(user);
                userview.IsAdminRole = await _userManager.IsInRoleAsync(user, "Admin");
                return userview;
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

        private UserView UserToUserView(ApplicationUser user)
        {
            return new UserView
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Wallet=user.Wallet,                
                Avatar = user.Avatar,
                AvatarUrl = string.IsNullOrWhiteSpace(user.Avatar) ?
                  "/img/account.jpg"
                  : string.Format("/img/avatar/{0}?v={1:yyyyMMddHHmmssff}", user.Avatar, DateTime.Now)
            };

        }





    }
}
