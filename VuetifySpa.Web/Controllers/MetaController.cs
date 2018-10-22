using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuetifySpa.Data;

namespace VuetifySpa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaTagController : Controller
    {

        private MyDbContext _db;
        public MetaTagController(MyDbContext db)
        {
            _db = db;
        }


        [HttpPost]
        public void Post([FromBody]string value)
        {
            
        }

    }


}


