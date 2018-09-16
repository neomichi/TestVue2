using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuetifySpa.Data.ViewModel
{
    public class GridDataView
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string OrderCity { get; set; }

        public int OrderPrice { get; set; }

        public DateTime StartTime { get; set; }

        public string StartAdress { get; set; }

        public string DestAdress { get; set; }
        public string CarType { get; set; }

        public bool Reserved { get; set; }
    }
}
