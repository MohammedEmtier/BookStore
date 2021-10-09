using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    public class AutherController : Controller
    {
        private readonly IBookRepository<AutherModel> autherRepository;

        public AutherController(IBookRepository<AutherModel> autherRepository)
        {
            this.autherRepository = autherRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
          
                var authers = autherRepository.List();
                return View(authers);
            
        }

        public IActionResult Details(int id)
        {
            var authersDetails = autherRepository.Find(id);
            return View(authersDetails);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AutherModel
            auther)
        {
            try {
                autherRepository.Add(auther);
                return RedirectToAction(nameof(Index
                    )); }

            catch
            {
                return View();
            }
        }
    
    public ActionResult Edit(int id)
    {
            var author = autherRepository.Find(id);

        return View(author);
    }

    // POST: Author/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, AutherModel author)
    {
        try
        {
                autherRepository.Update(author,id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Author/Delete/5
    public ActionResult Delete(int id)
    {
        var author = autherRepository.Find(id);

        return View(author);
    }

    // POST: Author/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, AutherModel author)
    {
        try
        {
                autherRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
}
