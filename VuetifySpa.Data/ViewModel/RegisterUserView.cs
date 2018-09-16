using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VuetifySpa.Data.ViewModel
{
    public class RegisterUserView
    {
        [Required]
        [MaxLength(64)]
        public string Email { get; set; }
        [Required]
        [MaxLength(160)]
        public string FirstName { get; set; }
        [MaxLength(160)]
        public string LastName { get; set; }
        [MaxLength(160)]
        public string AvatarUrl { get; set; }

        public int Wallet { get; set; } = 0;
        [Required]
        [MaxLength(32)]
        public string Password { get; set; }

        public bool isPersistent { get; set; } = false;

    }
}
