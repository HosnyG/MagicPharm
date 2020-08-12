using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Entites
{
    public class Category
    {

        [BindNever]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(maximumLength:20,MinimumLength =1)]
        [Display(Name="קטגוריה")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "תמונת רקע")]
        public string ImageUrl { get; set; }

        public List<Product> Products { get; set; }
    }
}
