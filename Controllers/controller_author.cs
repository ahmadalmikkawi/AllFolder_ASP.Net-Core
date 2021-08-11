using Book_Store.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    public class controller_author : Controller
    {
        private readonly interface_repository<Author> control_Author;

        public controller_author(interface_repository<Author> control_author)
        {
            this.control_Author = control_author;
        }
        // GET: controller_author
        public ActionResult Index()
        {
            var page =  control_Author.List_Item();
            return View(page);
        }

        // GET: controller_author/Details/5
        public ActionResult Details(int id)
        {
            var auth = control_Author.Find(id);
            return View(auth);
        }

        // GET: controller_author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: controller_author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
               control_Author.add(author);
               return RedirectToAction("Index");
            }
            return View();
        }

        // GET: controller_author/Edit/5
        public ActionResult Edit(int id)
        {
            var auth = control_Author.Find(id);
            return View(auth);
        }

        // POST: controller_author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Author auth)
        {
            try
            {
                control_Author.update(id, auth);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: controller_author/Delete/5
        public ActionResult Delete(int id)
        {
            var auth = control_Author.Find(id);
            return View(auth);
        }

        // POST: controller_author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author auth)
        {
            try
            {
                control_Author.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
