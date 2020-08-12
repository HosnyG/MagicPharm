using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories.interfaces;
using MagicPharm.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MagicPharm.Controllers
{

    [Authorize(Roles = "Admin")]

    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IHostingEnvironment _hosting;

        public CategoryController(ICategoryRepository categoryRepo, IHostingEnvironment hosting)
        {
            this._categoryRepo = categoryRepo;
            this._hosting = hosting;
        }
        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAll();
            return View(categories);
        }

        [AllowAnonymous]
        public ActionResult Details(Guid id)
        {
            var category = _categoryRepo.Find(id);
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryVM model)
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
                    string uploads = Path.Combine(_hosting.WebRootPath, "images/categories");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));

                }
                Category category = new Category
                {
                    Name = model.Name,
                    ImageUrl = fileName
                };
                this._categoryRepo.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            Category category = _categoryRepo.Find(id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        // POST: Carousel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(Guid id)
        {
            try
            {
                _categoryRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}