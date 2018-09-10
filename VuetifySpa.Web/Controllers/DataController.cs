using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VuetifySpa.Data;
using VuetifySpa.Data.Models;
using VuetifySpa.Web.Models;

namespace VuetifySpa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/data")]
    public class DataController : Controller
    {
        private MyDbContext _db;

        public DataController(MyDbContext db)
        {
            _db = db;   
        }


        // GET: api/Default1/5
        [HttpGet]
        public JsonResult Get()
        {
            var data = new List<GridDataView>
            {
                new GridDataView
                {
                    OrderId=1,
                    OrderCity="екатеринбург12",
                    OrderPrice=15,
                    Reserved=false,
                    DestAdress="екатеринбург 33",
                    StartAdress="екатеринбург 44",
                    StartTime=DateTime.Now.AddDays(-15),
                    CarType="Автобусы 15 Комфорт"
                },
                 new GridDataView
                {
                    OrderId=1,
                    OrderCity="екатеринбург12",
                    OrderPrice=151,
                    Reserved=false,
                    DestAdress="екатеринбург 53",
                    StartAdress="екатеринбург 54",
                    StartTime=DateTime.Now.AddDays(-11),
                    CarType="Автобусы 36 Комфорт"
                }, new GridDataView
                {
                    OrderId=1,
                    OrderCity="екатеринбург123",
                    OrderPrice=15,
                    Reserved=false,
                    DestAdress="екатеринбург 311",
                    StartAdress="екатеринбург 411",
                    StartTime=DateTime.Now.AddDays(-255),
                    CarType="Автобусы 54 Комфорт"
                }
            };
            
            return Json(data);
        }

        //// POST: api/Default1
        // [HttpPost]
        //public async Task<IActionResult> Post([FromBody]AuthLoginView authLoginView)
        //{
        //    _UserManager.
        //    return await SignHelper(user);
        //}

        // PUT: api/Default1/5
        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody]RegisterUserView user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var AppUser = new ApplicationUser();
        //        user.Email = user.Email;
              
        //        //_signInManager.SignInAsync()
        //    }
        //    return Json("false");
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return Ok();
        //}

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
