using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VuetifySpa.Data.ViewModel
{
    public class MessageView
    {
        public Guid Id { get; set; }
        public Guid ToId { get; set; }

        [Required]
        public Guid FromId { get; set; }
        public string FromFio { get; set; }       
        public string FromAvatarUrl { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        [MaxLength(600)]
        public string Text { get; set; }

        [Required]
        [MaxLength(140)]
        public string Title { get; set; }

        public bool IsReaded { get; set; }
    }
}
