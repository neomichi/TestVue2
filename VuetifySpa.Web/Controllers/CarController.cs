using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CarController : Controller
    {
        private MyDbContext _db;
        private ICarService _carService;

        public CarController(MyDbContext db, ICarService carService)
        {
            _db = db;
            _carService = carService;
        }


        // GET: api/Default1/5
       
        [HttpGet]
        public IActionResult Get()
        {  
            return Json(_db.Cars.Where(x=>x.Visible).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid Id)
        {
 
            var car = _db.Cars.SingleOrDefault(x => x.Id == Id);
            if (car != null)
            {
                return Json(car);
            }
            var message = "не найдена";
            return BadRequest(message);
        }

        //// POST: api/Default1
        // [HttpPost]
        //public async Task<IActionResult> Post([FromBody]AuthLoginView authLoginView)
        //{
        //    _UserManager.
        //    return await SignHelper(user);
        //}

        //PUT: api/Default1/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CarView car)
        {
            if (ModelState.IsValid)
            {    
                return Json(_carService.Update(car));

            }
            return Json("false");
        }

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
