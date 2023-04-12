using KlinikaPlusWeb.Data;
using KlinikaPlusWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace KlinikaPlusWeb.Controllers
{
    public class NalaziController : Controller
    {
        private readonly KlinikaPlusDbContext _db;

        public NalaziController(KlinikaPlusDbContext db)
        {
            _db = db;
        }

        //GET
        [HttpGet]
        public IActionResult Create(int pid)
        {
            Nalaz nalaz = new Nalaz() { PrijemId=pid, Prijem=_db.Prijemi.FirstOrDefault(p=>p.Id==pid)};
            return View(nalaz);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Nalaz obj)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Prijemi");
            }
            _db.Database.OpenConnection();
            Nalaz nalaz = new Nalaz() { PrijemId = obj.PrijemId, TekstualniOpis = obj.TekstualniOpis};
            try
            {
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Nalazi ON");
                _db.Nalazi.Add(nalaz);
                _db.Prijemi.Find(obj.PrijemId).NalazId=obj.PrijemId;
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Nalazi OFF");
                return RedirectToAction("Index", "Prijemi");
            }
            finally
            {
                _db.Database.CloseConnection();
            }
        }

        [HttpGet]
        public IActionResult Details(int pid)
        {
            Nalaz nalaz = _db.Nalazi.FirstOrDefault(n=>n.PrijemId==pid);
            if (nalaz!=null)
            {
                return View(nalaz);
            }
            return NotFound();
        }
    }
}
