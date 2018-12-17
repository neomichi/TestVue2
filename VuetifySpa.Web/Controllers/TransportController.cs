using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Hosting;
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
        private IHostingEnvironment _hostingEnvironment;

        public TransportController(ITransportService transportService, IHostingEnvironment hostingEnvironment)
        {
            _transportService = transportService;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: api/Default1/5

        [HttpPost]
        public IActionResult Post([FromBody]TransportDataTableView transportDataTableView)
        {

            if (transportDataTableView.ExportData != null)
            {
                var table = _transportService.ExportTable(transportDataTableView);

                if (transportDataTableView.ExportType == Data.Enum.ExportType.Excell)
                {
                    var bytes = Code.ExcellExport(table);
                    return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "export.xlsx");
                }
                if (transportDataTableView.ExportType == Data.Enum.ExportType.Pdf)
                {
                    var bytes=Code.ExportToPdf(table, _hostingEnvironment);
                    return File(bytes, "application/pdf", "export.pdf");
                }

            }

           var data= _transportService.DataTableHandler(transportDataTableView);

            return Json(new
            {
                Items = data.Item2,
                Total = data.Item1
            });
        }
    }
}
