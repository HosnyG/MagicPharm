using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.ViewModel
{
    public class CarouselVM
    {
        public int CarouselId { get; set; }

        [Required]
        [Display(Name ="עדיפות")]
        public int Priority { get; set; }

        [Required]
        [Display(Name ="בחר תמונה")]
        public IFormFile File { get; set; }

        public string ImgUrl { get; set; }
    }
}
