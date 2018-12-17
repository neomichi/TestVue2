using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VuetifySpa.Data;
using VuetifySpa.Data.Services;
using VuetifySpa.Data.ViewModel;


namespace VuetifySpa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransportController : Controller
    {
        private ITransportService _transportService;
        private IHttpContextAccessor _httpContextAccessor;

        public TransportController(ITransportService transportService, IHttpContextAccessor httpContextAccessor)
        {
            _transportService = transportService;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: api/Default1/5

        [HttpPost]
        public IActionResult Post([FromBody]TransportDataTableView transportDataTableView)
        {
            var data = _transportService.DataTableHandler(transportDataTableView);
            if (transportDataTableView.ExcelData != null)
            {
                var bytes = _transportService.ExportExcell(transportDataTableView);
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "машины_и_водители.xlsx");
            }

            return Json(new
            {
                Items = data.Item2,
                Total = data.Item1
            });
        }
    }
}
