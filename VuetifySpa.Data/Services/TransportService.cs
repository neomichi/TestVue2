using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VuetifySpa.Data.Model;
using VuetifySpa.Data.ViewModel;


namespace VuetifySpa.Data.Services
{
    public class TransportService : ITransportService
    {
        private IHostingEnvironment _hostingEnviroment;
      
        private MyDbContext _db;
        public TransportService(MyDbContext db, IHostingEnvironment hostingEnviroment)
        {
            _db = db;
            _hostingEnviroment = hostingEnviroment;
            
        }



        private IQueryable<Transport> GetTransport(TransportDataTableView transportView)
        {
            var transports = _db.Transports.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(transportView.Search))
            {
                transports = transports.Where(x => x.Brand.ToLower().Contains(transportView.Search.ToLower()));
            }

            transports = transportView.descending
                 ? transports.OrderByDescending(transportView.sortBy)
                 : transports.OrderBy(transportView.sortBy);

            return transports;
        }

        public Tuple<int, List<Transport>> DataTableHandler(TransportDataTableView transportView)
        {
            var transports = GetTransport(transportView);

            var count = transports.Count();
            var data = transports.Skip((transportView.page - 1) * transportView.rowsPerPage).Take(transportView.rowsPerPage).ToList();
            return Tuple.Create(count, data);
        }



        public List<ExportDataView> ExportTable(TransportDataTableView transportView)
        {
            var transports = GetTransport(transportView);

            if (transportView.ExportData.Length>0)
            {
                transports = transports.Where(x => transportView.ExportData.Contains(x.Id));
            } 

            var export = new List<ExportDataView>
                {
                    new ExportDataView()
                    {
                        WorkSheetTitle = "список транспорта",
                        Title = "список транспорта",
                        Header = new List<string>()
                    {
                        "марка",
                        "литров на 100км",
                        "трансмисcия",
                        "привод",
                        "тип двигателя",
                        "тип топлива",
                        "год выпуска",
                    },
                        Data = transports.Select(x => new List<string>()
                        {
                        x.Brand,
                        x.CityMpg.ToString(),
                        x.Classification,
                        x.Driveline,
                        x.EngineType,
                        x.FuelType,
                        x.Year.ToString()
                        }).ToList()
                    }
                };
            return export;
        }
    }
}
