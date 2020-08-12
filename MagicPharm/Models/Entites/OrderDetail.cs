using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace MagicPharm.Models.Entites
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
