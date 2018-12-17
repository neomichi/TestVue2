using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VuetifySpa.Data.ViewModel
{
    public class ExportDataView
    {
        public string WorkSheetTitle { get; set; }
        public List<string> Header { get; set; }

        public List<List<string>> Data { get; set; }

        public string Title { get; set; }
    }
}