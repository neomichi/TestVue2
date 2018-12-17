using System;
using System.Collections.Generic;
using System.Text;

namespace VuetifySpa.Data.ViewModel
{
    public class TransportDataTableView
    {
        public string sortBy { get; set; }
        public bool descending { get; set; }
        public int page { get; set; }
        public int rowsPerPage { get; set; }
        public string Search { get; set; }

        public Guid[] ExcelData { get; set; }

        public Guid[] PdfxcelData { get; set; }
    }


}
