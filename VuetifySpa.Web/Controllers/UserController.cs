using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VuetifySpa.Data;
using VuetifySpa.Data.Models;
using VuetifySpa.Data.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VuetifySpa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IHostingEnvironment _hostingEnviroment;
        private MyDbContext _db;
        private SignInManager<ApplicationUser> _signInManager;

        public UserController(MyDbContext db, SignInManager<ApplicationUser> signInManager, IHostingEnvironment hostingEnviroment)
        {
            _db = db;
            _signInManager = signInManager;
            _hostingEnviroment = hostingEnviroment;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = _db.Users.SingleOrDefault(x => x.Email.Equals(HttpContext.User.Identity.Name, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                {
                    return Json(user.GetRegisterUser());
                }
            }
            return NotFound(new { message = "is not authenticated" });

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateUserView userView)
        {
            var message = "";

            await Task.Delay(1000);

            var filename = string.Format("{0}{1}", userView.Id, userView.AvatarImgType);
            var filepath = System.IO.Path.Combine(_hostingEnviroment.WebRootPath, @"img\avatar\", filename);
            var webpath = string.Format("/img/avatar/{0}", filename);            
            Code.GetImage64Ext(userView.AvatarUrl, filepath);
            userView.AvatarUrl = webpath;


            if (ModelState.IsValid)
            {
                message = "bad data";              

                var user=_db.Users.SingleOrDefault(x => x.Id == userView.Id);
                if (user!=null)
                {                  
                    user.FirstName = userView.FirstName;
                    user.LastName = userView.LastName;
                    user.AvatarUrl = userView.AvatarUrl;
                    _db.Update(user);
                    _db.SaveChanges();
                    return Json(user);
                } else
                {
                    message = "user is not found";
                }
            }
            return NotFound(new { message });
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
