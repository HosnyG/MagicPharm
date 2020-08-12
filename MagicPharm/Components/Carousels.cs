using MagicPharm.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Components
{
    public class Carousels : ViewComponent
    {

        private readonly ICarouselRepository _carouselsRepo;

        public Carousels(ICarouselRepository categoryRepository)
        {
            this._carouselsRepo = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = this._carouselsRepo.GetAll().OrderBy(p => p.Priority).ToList();
            return View(categories);
        }
    }
}
