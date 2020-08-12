using MagicPharm.Models.Context;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories.interfaces;
using System;

namespace MagicPharm.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order = _context.Orders.Add(order).Entity;
            _context.SaveChanges();

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach(var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    OrderId = order.OrderId,
                    Price = item.Product.Price
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
