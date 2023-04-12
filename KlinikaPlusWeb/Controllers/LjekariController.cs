using KlinikaPlusWeb.Data;
using KlinikaPlusWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KlinikaPlusWeb.Controllers
{
    public class LjekariController : Controller
    {
        private readonly KlinikaPlusDbContext _db;

        public LjekariController(KlinikaPlusDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var objLjekari = _db.Ljekari.ToList();
            return View(objLjekari);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ljekar obj)
        {
            if (ModelState.IsValid)
            {
                _db.Ljekari.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? Id)
        {
            if (Id==null)
            {
                return NotFound();
            }
            var objLjekari = _db.Ljekari.FirstOrDefault(p=>p.Id==Id);
            return View(objLjekari);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ljekar obj)
        {
            if (ModelState.IsValid)
            {
                _db.Ljekari.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _db.Ljekari.FirstOrDefault(p => p.Id == Id);
            if (obj==null)
            {
                return NotFound();
            }
            _db.Ljekari.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
