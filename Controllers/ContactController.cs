using aspconsoleapp.Models;
using aspconsoleapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace aspconsoleapp.Controllers
{
    [Authorize]   // Add protection and redicrest unauhorized user to the login-page
    public class ContactController : Controller
    {
        private readonly IContact _contactRepository;

        public ContactController(IContact IContact)
        {
            _contactRepository = IContact;
        }
        /* 
        public IActionResult index()
        {
            //ViewBag.demo = _contactRepository.GetallContacts();
            return View();
        }
        */
        
        public IActionResult List()
        {
            ViewBag.demo = _contactRepository.GetallContacts();

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // Addtional protection for cross-posting
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.addContact(contact);

                return RedirectToAction("list");
            }

            return View(contact);
        }

        public IActionResult Delete( int id)
        {
            _contactRepository.DeleteContact(id);
            return RedirectToAction(nameof(ContactController.List),"Contact");
        }

        public IActionResult Edit(int id)
        {

           var contact = _contactRepository.GetContact(id);

           return View(contact);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {
            if(ModelState.IsValid)
            {
              _contactRepository.Update(contact);

              return RedirectToAction(nameof(ContactController.List), "Contact");

            }
            return View(contact);

        } 

   









    }
}