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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicPharm.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CarouselController : Controller
    {
        private readonly ICarouselRepository _carouselRepo;
        private readonly IHostingEnvironment _hosting;

        public CarouselController(ICarouselRepository carouselRepo,
            IHostingEnvironment hosting)
        {
            this._carouselRepo = carouselRepo;
            this._hosting = hosting;
        }
        public ActionResult Index()
        {
            var carousels = _carouselRepo.GetAll().OrderBy(d=>d.Priority);
            return View(carousels);
        }

        public ActionResult Details(int id)
        {
            var carousel = _carouselRepo.Find(id);
            return View(carousel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarouselVM model)
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
                    string uploads = Path.Combine(_hosting.WebRootPath, "images/carousels");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));

                }
                Carousel carousel = new Carousel
                {
                    Priority = model.Priority,
                    ImageUrl = fileName
                };
                this._carouselRepo.Add(carousel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Carousel carousel = _carouselRepo.Find(id);
            if (carousel == null)
                return NotFound();
            var vm = new CarouselVM
            {
                CarouselId = id,
                ImgUrl = carousel.ImageUrl,
                Priority = carousel.Priority
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarouselVM model)
        {
            try
            {
                if (!ModelState.IsValid) //server side validaiton
                {
                    ModelState.AddModelError("", "You have to fill all requiered fields!.");
                    return Edit(model.CarouselId);
                }
                string fileName = string.Empty;
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, "images/carousels");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    //delete the old file
                    string oldFileName = this._carouselRepo.Find(id).ImageUrl;
                    string fullOldPath = Path.Combine(uploads, oldFileName);

                    if (fullPath != fullOldPath)
                    {
                        // System.IO.File.Delete(fullOldPath);
                        //save the new file
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                }
                Carousel carousel = new Carousel
                {
                    Id = model.CarouselId,
                    Priority = model.Priority,
                    ImageUrl = fileName
                };
                this._carouselRepo.Update(carousel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Carousel/Delete/5
        public ActionResult Delete(int id)
        {
            Carousel carousel = _carouselRepo.Find(id);
            if (carousel == null)
                return NotFound();
            return View(carousel);
        }

        // POST: Carousel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                _carouselRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}