using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ZanrController : Controller
    {
        // GET: zanr
        public ActionResult Index()
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var zanrovi = bdb.Zanr.ToList();

            return View(zanrovi);
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: Knjiga
        [HttpPost]
        public ActionResult Create(ZanrModel zm)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var zanr = new ZanrModel();

            zanr.Naziv = zm.Naziv;

            bdb.Zanr.Add(zanr);
            bdb.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var zanr = bdb.Zanr.FirstOrDefault(a => a.Id == id);

            return View(zanr);
        }

        [HttpPost]
        public ActionResult Edit(ZanrModel zm)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var zanr = bdb.Zanr.FirstOrDefault(a => a.Id == zm.Id);

            zanr.Naziv = zm.Naziv;

            bdb.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            BibliotekaDB bdb = new BibliotekaDB();
            ZanrModel zanr = bdb.Zanr.Find(id);
            if (zanr == null)
            {
                return HttpNotFound();
            }
            return View(zanr);
        }

        // GET: Knjiga
        [HttpPost]
        public ActionResult Delete(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var zanr = bdb.Zanr.FirstOrDefault(a => a.Id == id);

            bdb.Zanr.Remove(zanr);
            bdb.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var zanr = bdb.Zanr.FirstOrDefault(a => a.Id == id);

            return View(zanr);
        }
    }
}