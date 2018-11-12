using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VuetifySpa.Data;
using VuetifySpa.Data.Models;
using VuetifySpa.Data.Services;
using VuetifySpa.Data.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VuetifySpa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {

        private IHostingEnvironment _hostingEnviroment;
        private MyDbContext _db;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;

        public UserController(MyDbContext db, IUserService userService, SignInManager<ApplicationUser> signInManager, IHostingEnvironment hostingEnviroment)
        {
            _db = db;
            _signInManager = signInManager;
            _userService = userService;
        }

        // GET: api/<controller>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var message = "пожалуйста, авторизирутесь";
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                await Task.Delay(1000);
                message = "указаный пользователь не найден";
                var user = await _userService.GetUserViewFromEmail(HttpContext.User.Identity.Name);

                if (user != null)
                {
                    return Json(user);
                }
            }
            return BadRequest(message);
        }


        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UserView user)
        {
            var message = "";

            await Task.Delay(1000);

            if (ModelState.IsValid)
            {
                var userView = await _userService.UpdateUser(user);
                if (userView != null) return Json(userView);
                message = "указаный пользователь не найден";
            }
            return BadRequest(message);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
