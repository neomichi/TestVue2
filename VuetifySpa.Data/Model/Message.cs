using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VuetifySpa.Data.Models;

namespace VuetifySpa.Data.Model
{
    public class Message : Entity
    {
        public ApplicationUser FromUser { get; set; }
        public ApplicationUser To { get; set; }
        [Required]
        public Guid FromUserId { get; set; }
        [Required]
        public Guid ToId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        [MaxLength(600)]
        public string Text { get; set; }

        [Required]
        [MaxLength(140)]
        public string Title { get; set; }

        public bool IsReaded { get; set; } = false;
    }
}
