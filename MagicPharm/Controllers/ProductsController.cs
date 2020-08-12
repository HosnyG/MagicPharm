using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories.interfaces;
using MagicPharm.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MagicPharm.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ProductsController : Controller
    {
        private readonly IProductRepository _productsRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IHostingEnvironment _hosting;

        public ProductsController(IProductRepository productsRepo, ICategoryRepository categoryRepo
            , IHostingEnvironment hosting)
        {
            this._productsRepo = productsRepo;
            this._categoryRepo = categoryRepo;
            this._hosting = hosting;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Category> categories = _categoryRepo.GetAll().ToList();
            foreach(Category category in categories)
            {
                category.Products = _productsRepo.GetByCategory(category.Id).ToList() ;
            }
            return View(categories);
        }

        public IActionResult List(Guid categoryId)
        {   
            List<Product> products;
            if (categoryId.Equals("") || categoryId == null)
                products = _productsRepo.GetAll().ToList();
            else
            {
                products = _productsRepo.GetByCategory(categoryId).ToList();
                ViewBag.categoryName = _categoryRepo.Find(categoryId).Name;
                ViewBag.catId = categoryId;
            }
            return View(products);
        }


        [AllowAnonymous]
        public IActionResult ListView(Guid categoryId)
        {
            IEnumerable<Product> products;
            string currentCategory = string.Empty;
            try
            {
                products = _productsRepo.GetAll().Where(p => p.CategoryId == categoryId);
                currentCategory = _categoryRepo.Find(categoryId).Name;
            }catch(Exception)
            {
                products = _productsRepo.GetAll().OrderBy(n => n.Name);
                currentCategory = "כל המוצרים";
            }
            ViewBag.Name = currentCategory;
            return View(products);
        }

        [AllowAnonymous]

        public IActionResult Search(string term)
        {
            List<Product> products =  _productsRepo.Search(term).ToList();
            return View("ListView", products);
        }

        public IActionResult Edit(int id)
        {
            Product product = _productsRepo.Find(id);
            if (product == null)
                return NotFound();
            var vm = new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = product.Price,
                IsPreferred = product.IsPreferred,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductVM model)
        {
            if (!ModelState.IsValid) //server side validaiton
            {
                ModelState.AddModelError("", "You have to fill all requiered fields!.");
                return View(model);
            }
            try
            {
                string fileName = string.Empty;
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, "images/products");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));

                }
                Product product = new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription,
                    Price = model.Price,
                    IsPreferred = model.IsPreferred,
                    InStock = false,
                    CategoryId = model.CategoryId,
                    ImageUrl = fileName
                };
                this._productsRepo.Update(product);
                return RedirectToAction("List", "Products", new { @categoryId = model.CategoryId });
            }
            catch
            {
                return View(model);
            }
        }



        public IActionResult Create(Guid categoryId)
        {
            ProductVM vm = new ProductVM
            {
                CategoryId = categoryId,
            };
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM model)
        {
            if (!ModelState.IsValid) //server side validaiton
            {
                ModelState.AddModelError("", "You have to fill all requiered fields!.");
                return View(model);
            }
            try
            {
                string fileName = string.Empty;
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, "images/products");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));

                }
                Product product = new Product
                {
                    Name = model.Name,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription,
                    Price = model.Price,
                    IsPreferred = model.IsPreferred,
                    InStock = false,
                    CategoryId = model.CategoryId,
                    ImageUrl = fileName
                };
                this._productsRepo.Add(product);
                return RedirectToAction("List", "Products", new { @categoryId = model.CategoryId });
            }
            catch
            {
                return View(model);
            }
        }


        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                Guid categoryId = _productsRepo.Find(id).CategoryId;
                _productsRepo.Delete(id);
                return RedirectToAction("List", "Products", new { @categoryId = categoryId });
            }
            catch
            {
                return NotFound();
            }
        }

        public ActionResult Details(int id)
        {
            return View(_productsRepo.Find(id));
        }

    }
}