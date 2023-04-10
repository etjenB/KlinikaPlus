using KlinikaPlusWeb.Data;
using KlinikaPlusWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KlinikaPlusWeb.Controllers
{
    public class PacijentiController : Controller
    {
        private readonly KlinikaPlusDbContext _db;

        public PacijentiController(KlinikaPlusDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var objPacijenti = _db.Pacijenti.ToList();
            return View(objPacijenti);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pacijent obj)
        {
            if (ModelState.IsValid)
            {
                _db.Pacijenti.Add(obj);
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
            var objPacijenti = _db.Pacijenti.FirstOrDefault(p=>p.Id==Id);
            return View(objPacijenti);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pacijent obj)
        {
            if (ModelState.IsValid)
            {
                _db.Pacijenti.Update(obj);
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
            var obj = _db.Pacijenti.FirstOrDefault(p => p.Id == Id);
            if (obj==null)
            {
                return NotFound();
            }
            _db.Pacijenti.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
