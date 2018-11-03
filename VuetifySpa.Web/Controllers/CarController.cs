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
        private ICarService _carService;

        public CarController(ICarService carService)
        {           
            _carService = carService;
        }


        // GET: api/Default1/5
       
        [HttpGet]
        public IActionResult Get()
        {  
            return Json(_carService.GetAllCar());
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(Guid Id)
        //{
 
        //    var car = _db.Cars.SingleOrDefault(x => x.Id == Id);
        //    if (car != null)
        //    {
        //        return Json(car);
        //    }
        //    var message = "не найдена";
        //    return BadRequest(message);
        //}

       

        //PUT: api/Default1/5
        [HttpPut]
        public IActionResult Put([FromBody]CarView car)
        {
            if (ModelState.IsValid)
            {    
                return Json(_carService.CreateOrUpdate(car));
            }
            return Json("false");
        }

        [HttpPost]
        [Route("validate/title")]
        public IActionResult Car([FromBody] CarValidateView carValidate)
        {
            if (ModelState.IsValid)
            {
                return Ok(_carService.IsUniqueTitle(carValidate));
            }
            return Ok(false);
        }

    }
}
