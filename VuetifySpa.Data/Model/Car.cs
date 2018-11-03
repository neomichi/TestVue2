using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VuetifySpa.Data.Model
{
    public class Car:Entity
    {   [Required]
        [MaxLength(40)]
        public string Title { get; set; }
        [MaxLength(120)]
        public string CarClass { get; set; }
        [MaxLength(120)]
        public string Description { get; set; } 
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int BirthYear { get; set; }

        public int Quantity { get; set; }
        [MaxLength(120)]
        public string CarType { get; set; }
        [MaxLength(120)]
        public string Status { get; set; }
        [MaxLength(120)]
        public string Transmission { get; set; }
        [MaxLength(120)]
        public string Color { get; set; }
        [MaxLength(160)]
        public string Img { get; set; }

        public bool Visible { get; set; } = false;


        [MaxLength(120)]
        public string Motor { get; set; }

      

        
    }
}
