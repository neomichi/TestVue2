using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VuetifySpa.Data.ViewModel
{
    public class CarValidateView
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
