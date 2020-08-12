using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Entites
{
    public class Carousel
    {
        [Required]
        [BindNever]
        public int Id { set; get; }

        [Display(Name = "עדיפות")]
        public int Priority { set; get; }
        [Display(Name = "תמונה")]
        public string ImageUrl { set; get; }
    }
}
