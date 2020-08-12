using MagicPharm.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = this._categoryRepository.GetAll().OrderBy(p => p.Name);
            return View(categories);
        }
    }
}
