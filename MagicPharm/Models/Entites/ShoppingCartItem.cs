using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicPharm.Models.Entites
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
