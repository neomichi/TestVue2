using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDotnetSSR.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedData { get; set; }
        public Double Milage { get; set; }
        public Double Price {get;set;}
        public int Quantity { get; set; }
        public int HasBuyed { get; set; }
        public string Photo { get; set; }

    }
}
