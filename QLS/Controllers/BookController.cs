using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLS.Models;

namespace QLS.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BookController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> Book = _appDbContext.Book.Include(p => p.Category);

            return View(Book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book Book)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Book.Add(Book);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Book);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var Book = _appDbContext.Book.Find(id);
            if (Book == null) return NotFound();

            return View(Book);
        }

        [HttpPost]
        public IActionResult Edit(Book Book)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Book.Update(Book);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Book);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var Book = _appDbContext.Book.Find(id);
            if (Book == null) return NotFound();

            return View(Book);
        }

        [HttpPost]
        public IActionResult DeleteBook(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var Book = _appDbContext.Book.Find(id);
            if (Book == null) return NotFound();

            _appDbContext.Book.Remove(Book);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}