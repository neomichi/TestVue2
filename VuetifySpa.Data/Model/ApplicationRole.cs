using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuetifySpa.Data.Models
{
    public class ApplicationRole : IdentityRole<Int64>
    {
        public string Description { get; set; }
    }
}
