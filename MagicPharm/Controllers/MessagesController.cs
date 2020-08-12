using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicPharm.Models.Entites;
using MagicPharm.Models.Repositories.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MagicPharm.Controllers
{
    [Authorize(Roles = "Admin")]

    public class MessagesController : Controller
    {
        private readonly IMessageRepository _messageRepo;

        public MessagesController(IMessageRepository messageRepo)
        {
            this._messageRepo = messageRepo;
        }

       
        public IActionResult Index()
        {
            List<Message> messages = _messageRepo.GetAll().ToList() ;
            return View(messages);
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message message)
        {
            if (!ModelState.IsValid) //server side validaiton
            {
                ModelState.AddModelError("", "You have to fill all requiered fields!.");
                return RedirectToAction("ContactUs", "Home");
            }
            try
            {
                _messageRepo.Create(message);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return NotFound();
            }
        }

       
        [HttpPost]
        public ActionResult ConfirmDelete(Guid id)
        {
            try
            {
                _messageRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index","Home");
            }
        }




    }
}