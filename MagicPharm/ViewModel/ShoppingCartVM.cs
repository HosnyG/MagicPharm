using MagicPharm.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.ViewModel
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        
        public List<Category> Categories { get; set; }
    }
}
