using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VuetifySpa.Data.Model
{
    public class Car:Entity
    {
        [MaxLength(120)]
        public string Title { get; set; }
        [MaxLength(120)]
        public string CarType { get; set; }
        [MaxLength(120)]
        public string Description { get; set; }     

        public int BirthYear { get; set; }

        public int Quantity { get; set; }
        [MaxLength(120)]
        public string CarCase { get; set; }
        [MaxLength(120)]
        public string Status { get; set; }
        [MaxLength(120)]
        public string Transmission { get; set; }
        [MaxLength(120)]
        public string Color { get; set; }
        [MaxLength(160)]
        public string Avatar { get; set; }
        [MaxLength(120)]
        public string Motor { get; set; }
    }
}
