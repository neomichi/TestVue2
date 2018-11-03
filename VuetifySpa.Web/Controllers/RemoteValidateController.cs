using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuetifySpa.Data;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Web.Controllers
{
    [Route("api/Validate")]
    [ApiController]
    public class RemoteValidateController : ControllerBase
    {
        private MyDbContext _db;
        public RemoteValidateController(MyDbContext db)
        {
            _db = db;
        }


        [HttpPost]
        [Route("Email")]
        public IActionResult Email([FromBody] EmailView emailView)
        {
            if (!string.IsNullOrEmpty(emailView.email) && emailView.email.IndexOf('@') > -1)
            {
                if (!_db.Users.Any(x => x.Email.Equals(emailView.email, StringComparison.OrdinalIgnoreCase)))
                {
                    return Ok(true);
                }                
            }
            return Ok(false);
        }

      
    }
}