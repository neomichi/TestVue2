using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VuetifySpa.Data.ViewModel
{
    public class CarView
    {  
        public Guid Id { get; set; }

        [MaxLength(120)]
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        [Required]
        [MaxLength(120)]
        public string CarType { get; set; }
        [MaxLength(120)]
        public string Description { get; set; }
        [Required]
        public int BirthYear { get; set; }
        [Required]
        public int Quantity { get; set; }
        [MaxLength(120)]
        [Required]
        public string CarClass { get; set; }
        [MaxLength(120)]
        [Required]
        public string Status { get; set; }
        [MaxLength(120)]
        [Required]
        public string Transmission { get; set; }
        [MaxLength(120)]
        [Required]
        public string Color { get; set; }

        [Required]
        public bool Visible { get; set; } = false;


        [MaxLength(120)]
        public string Motor { get; set; }
       
        public string GetImg { get; set; }
        
        public string ImgType { get; set; }

        public string Img { get; set; }


    }
}
