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
using VuetifySpa.Data.ViewModel;


namespace VuetifySpa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private MyDbContext _db;
        private SignInManager<ApplicationUser> _signInManager;

        public AuthController(MyDbContext db, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _signInManager = signInManager;
        }


        // GET: api/Default1/5
        [HttpGet]
        public IActionResult Get()
        {
            
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _db.Users.SingleOrDefault(x => x.Email.Equals(HttpContext.User.Identity.Name, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                {
                    return Json(user.GetRegisterUser());
                }
            }
            return BadRequest("пожалуйста, авторизирутесь");
        }       

        //// POST: api/Default1
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthLoginView authLoginView)
        {
            var message = "вы уже авторизированы";
            await Task.Delay(1000);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                message = "неверная комбинация";
                if (ModelState.IsValid)
                {
                    var user = await _signInManager.UserManager.FindByEmailAsync(authLoginView.Email);
                    if (user != null)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, authLoginView.Password, authLoginView.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return Json(user.GetRegisterUser());
                        }
                    }
                }                
            }
            
            return BadRequest( message );
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
                    var appUser = new ApplicationUser
                    {
                        Id = Guid.NewGuid(),
                        Email = user.Email,
                        UserName = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                    var responseUser = await _signInManager.UserManager.CreateAsync(appUser, user.Password);
                    await _signInManager.SignInAsync(appUser, isPersistent: user.isPersistent);
                    return Json(appUser.GetRegisterUser());
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
        //        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        //        return Json(user);
        //    }
        //    return Json("");
        //}


    }
}
