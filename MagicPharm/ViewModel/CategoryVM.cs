using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.ViewModel
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name="שם קטגוריה")]
        public string Name { get; set; }

        [Required]
        [Display(Name="שם קטגוריה")]
        public IFormFile File { get; set; }

        public string ImgUrl { get; set; }
    }
}
