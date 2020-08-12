using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories.interfaces;
using MagicPharm.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MagicPharm.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly ICategoryRepository _categoryRepository;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart,
            ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._shoppingCart = shoppingCart;
            this._categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var vm = new ShoppingCartVM
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                Categories = _categoryRepository.GetAll().ToList()
                
            };
            return View(vm);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.GetAll().FirstOrDefault(p => p.Id == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.GetAll().FirstOrDefault(p => p.Id == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }

    }
}