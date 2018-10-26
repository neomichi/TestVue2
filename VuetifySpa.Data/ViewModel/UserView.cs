using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VuetifySpa.Data.ViewModel
{
    public class UserView
    {
        [Required]
        public Guid Id { get; set; }      
        [Required]
        [MaxLength(160)]
        public string FirstName { get; set; }
        [MaxLength(160)]
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string AvatarUrl { get; set; }
        public string ImgType { get; set; }

        [Required]
        public bool IsAdminRole { get; set; }

        public int Wallet { get; set; } = 0;
    }
}
