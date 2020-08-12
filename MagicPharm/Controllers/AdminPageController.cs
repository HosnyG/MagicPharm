using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MagicPharm.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}