using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Display(Name = "שם מוצר")]
        public string Name { get; set; }
        [Display(Name = "תיאור קצר")]
        public string ShortDescription { get; set; }

        [Display(Name = "תיאור ארוך")]
        public string LongDescription { get; set; }

        [Display(Name = "מחיר")]
        public decimal Price { get; set; }

        [Display(Name = "תמונה")]
        public string ImageUrl { get; set; }

        [Display(Name = "מועדף")]
        public bool IsPreferred { get; set; }

        [Required]
        [Display(Name="בחר תמונה")]
        public IFormFile File { get; set; }

        public Guid CategoryId { get; set; }
    }
}
