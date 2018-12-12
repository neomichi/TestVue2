using System;
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
using VuetifySpa.Data.ViewModel;
using VuetifySpa.Web.Helper;

namespace VuetifySpa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransportController : Controller
    {
        private MyDbContext _db;
        private IHttpContextAccessor _httpContextAccessor;

        public TransportController(MyDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: api/Default1/5

        [HttpPost]
        public IActionResult Post([FromBody]DataTableTransportView dtv, IDataTablesRequest request, [FromBody]string sortBy)
        {
            var db = _db.Transports.AsNoTracking();

            var data = db.Skip((dtv.page - 1) * dtv.rowsPerPage).Take(dtv.rowsPerPage);
            return Json(new {
                Items = data.ToList(),
                Total = db.Count()
            });

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
            ? data
            : data.Where(_item => _item.Id.ToString().StartsWith(request.Search.Value) || _item.Title.StartsWith(request.Search.Value));
            
            var orderColums = request.Columns.Where(x => x.Sort != null);

            var dataPage = filteredData.OrderBy(orderColums).Skip(request.Start).Take(request.Length);

            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

            return new DataTablesJsonResult(response, true);
        }
    }
}
