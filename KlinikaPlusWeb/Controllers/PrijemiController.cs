using iText.Html2pdf;
using KlinikaPlusWeb.Data;
using KlinikaPlusWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KlinikaPlusWeb.Controllers
{
    public class PrijemiController : Controller
    {
        private readonly KlinikaPlusDbContext _db;

        public PrijemiController(KlinikaPlusDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var objPrijemi = _db.Prijemi.ToList();
            foreach (var p in objPrijemi)
            {
                p.Ljekar = _db.Ljekari.FirstOrDefault(l => l.Id == p.LjekarId);
                p.Pacijent = _db.Pacijenti.FirstOrDefault(pac => pac.Id == p.PacijentId);
            }
            return View(objPrijemi);
        }

        //GET Filtrirani prijemi
        public IActionResult FilterPrijemi(DateTime? dtOd, DateTime? dtDo)
        {
            if (dtOd==null||dtDo==null)
            {
                return RedirectToAction("Index");
            }
            var objPrijemi = _db.Prijemi.Where(p => p.DatumIVrijeme >= dtOd && p.DatumIVrijeme <= dtDo).ToList();
            foreach (var p in objPrijemi)
            {
                p.Ljekar = _db.Ljekari.FirstOrDefault(l => l.Id == p.LjekarId);
                p.Pacijent = _db.Pacijenti.FirstOrDefault(pac => pac.Id == p.PacijentId);
            }
            return View("Index", objPrijemi);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Prijem obj)
        {
            if (ModelState.IsValid)
            {
                obj.Ljekar = _db.Ljekari.FirstOrDefault(l => l.Id == obj.LjekarId);
                obj.Pacijent = _db.Pacijenti.FirstOrDefault(p => p.Id == obj.PacijentId);
                _db.Prijemi.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var objPrijemi = _db.Prijemi.FirstOrDefault(p => p.Id == Id);
            if (objPrijemi!=null)
            {
                objPrijemi.Ljekar = _db.Ljekari.FirstOrDefault(l => l.Id == objPrijemi.LjekarId);
                objPrijemi.Pacijent = _db.Pacijenti.FirstOrDefault(p => p.Id == objPrijemi.PacijentId);
            }
            return View(objPrijemi);
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
            var obj = _db.Prijemi.FirstOrDefault(p => p.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            var nal = _db.Nalazi.FirstOrDefault(n => n.PrijemId == obj.Id);
            if (nal != null) _db.Nalazi.Remove(nal);
            _db.Prijemi.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Export(string GridHtml)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                HtmlConverter.ConvertToPdf(GridHtml, stream);
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
    }
}
