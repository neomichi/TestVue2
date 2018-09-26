using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [PersonalData]
        [MaxLength(120)]
        public string FirstName { get; set; }
    
        [MaxLength(120)]
        public string LastName { get; set; }

        [MaxLength(160)]
        public string AvatarUrl { get; set; }

        public int Wallet { get; set; } = 0;

        public RegisterUserView GetRegisterUser()
        {
            return new RegisterUserView
            {
                Id=Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                AvatarUrl = string.IsNullOrWhiteSpace(AvatarUrl) ? "/img/account.jpg" : AvatarUrl,
                Wallet = Wallet,
                Password="",               
            };
        }

    }
}
