using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VuetifySpa.Data;
using VuetifySpa.Data.Models;
using VuetifySpa.Data.Services;
using VuetifySpa.Data.ViewModel;


namespace VuetifySpa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private MyDbContext _db;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;

        public AuthController(MyDbContext db, SignInManager<ApplicationUser> signInManager, IUserService userService)
        {
            _db = db;
            _signInManager = signInManager;
            _userService = userService;
        }



        [HttpGet]
        public IActionResult Get()
        {
            var message = "пожалуйста,авторизирутесь";
            if (HttpContext.User.Identity.IsAuthenticated)
            {              

                return Json(true);
            }
            return BadRequest(message);
        }

        //// POST: api/Default1
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthLoginView authLoginView)
        {
            var message = "вы уже авторизированы";
            await Task.Delay(1000);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                message = "неверная комбинация email пароль";
                if (ModelState.IsValid)
                {
                    var user = await _signInManager.UserManager.FindByEmailAsync(authLoginView.Email);
                    var result = await _signInManager.PasswordSignInAsync(user, authLoginView.Password, authLoginView.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Json(await _userService.GetUserViewFromEmail(user.Email));
                    }
                }
            }
            return BadRequest(message);
        }

        // PUT: api/Default1/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]RegisterUserView user)
        {

            var message = "вы уже авторизированы";
            await Task.Delay(1000);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                message = "проверьте правильность заполнения формы";
                if (ModelState.IsValid)
                {
                    var dbUser = new ApplicationUser
                    {
                        Email = user.Email,
                        UserName = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                    var responseUser = await _signInManager.UserManager.CreateAsync(dbUser, user.Password);
                    if (responseUser.Succeeded)
                    {                        
                        await _signInManager.SignInAsync(dbUser, isPersistent: user.isPersistent);
                        return Json(await _userService.GetUserViewFromUser(dbUser));
                    }

                }
            }
            return BadRequest(message);
        }

        //// DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _db.Users.SingleOrDefault(x => x.Email.Equals(HttpContext.User.Identity.Name, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    return Ok();
                }
            }
            return BadRequest("ошибка");
        }



        //private async Task<IActionResult> SignHelper(User user)
        //{
        //    if (user != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //         new Claim(ClaimTypes.Email, user.Email),
        //         new Claim(ClaimTypes.Sid, user.Id.ToString()),
        //         new Claim(ClaimTypes.Name, user.Fio),
        //         new Claim(ClaimTypes.Role, user.IsAdmin.ToString())
        //        };
        //        var claimsIdentity = new ClaimsIdentity(claims,  ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        //        return Json(user);
        //    }
        //    return Json("");
        //}

        //private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        //{


        //    var identity = await _signInManager.UserManager.CreateIdentityAsync(user);



        //    identity.AddClaim(new Claim(ClaimTypes.GivenName, your_profile == null ? string.Empty : your_profile.FirstName));
        //    identity.AddClaim(new Claim(ClaimTypes.Surname, your_profile == null ? string.Empty : your_profile.LastName));

        //    identity

        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        //}

    }
}
