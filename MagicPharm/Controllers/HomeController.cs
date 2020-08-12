using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MagicPharm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepo;

        public HomeController(IProductRepository productRepo)
        {
            this._productRepo = productRepo;
        }
        public IActionResult Index()
        {
            return View(_productRepo.GetPreferredProducts());
        }

        public ViewResult ContactUs()
        {
            return View(new Message());
        }
    }
}