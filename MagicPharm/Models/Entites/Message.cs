using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Entites
{
    public class Message
    {
        public Guid Id { get; set; }

        [Required]

        
        [Display(Name ="שם")]
        public string FullName { get; set; }

        [Display(Name = "מייל")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "טלפון")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(maximumLength:150)]
        [Display(Name = "הודעה")]
        public string Text { get; set; }
    }
}
