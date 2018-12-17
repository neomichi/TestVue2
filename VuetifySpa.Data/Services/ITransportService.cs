using System;
using System.Collections.Generic;
using System.Linq;
using VuetifySpa.Data.Model;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Services
{
    public interface ITransportService
    {
        Tuple<int, List<Transport>> DataTableHandler(TransportDataTableView transportView);
        
        byte[] ExportExcell(TransportDataTableView transportView);
    }
}