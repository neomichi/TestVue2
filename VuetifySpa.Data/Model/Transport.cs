using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VuetifySpa.Data.Model
{
    public class Transport : Entity
    {
      
        public int CityMpg { get; set; }
        [StringLength(200)]
        public string Classification { get; set; }
        [StringLength(200)]
        public string Driveline { get; set; }
        [StringLength(200)]
        public string EngineType { get; set; }
        [StringLength(200)]
        public string FuelType { get; set; }

        public int Height { get; set; }
        public int HighwayMpg { get; set; }

        public int HiHorsepower { get; set; }

        public bool Hybrid { get; set; }
        [StringLength(200)]
        public string Title { get; set; }

        public int Price { get; set; }
        [StringLength(200)]
        public string Brand { get; set; }

        public string ModelYear { get; set; }
        /// <summary>
        /// число передачь
        /// </summary>
        public int NumberofForwardGears { get; set; }

        public int Torque { get; set; }
        [StringLength(200)]
        public string Transmission { get; set; }
        [StringLength(200)]
        public string Width { get; set; }

        public int Year {get;set;}

        [NotMapped]
        public bool Selected { get; set; }

    }
}
