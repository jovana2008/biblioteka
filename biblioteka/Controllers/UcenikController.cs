using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UcenikController : Controller
    {
        // GET: Ucenik
        public ActionResult Index()
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var ucenici = bdb.Ucenik.ToList();

            return View(ucenici);
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: Knjiga
        [HttpPost]
        public ActionResult Create(UcenikModel um)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var ucenik = new UcenikModel();

            ucenik.Adresa = um.Adresa;
            ucenik.BrojUDnevniku = um.BrojUDnevniku;
            ucenik.Email = um.Email;
            ucenik.GodinaRodjenja = um.GodinaRodjenja;
            ucenik.Ime = um.Ime;
            ucenik.Prezime = um.Prezime;
            ucenik.Razred = um.Prezime;
            ucenik.Odeljenje = um.Odeljenje;
            ucenik.Telefon = um.Telefon;

            bdb.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var ucenik = bdb.Ucenik.FirstOrDefault(a => a.UcenikID == id);

            return View(ucenik);
        }

        [HttpPost]
        public ActionResult Edit(UcenikModel um)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var ucenik = bdb.Ucenik.FirstOrDefault(a => a.UcenikID == um.UcenikID);

            ucenik.Adresa = um.Adresa;
            ucenik.BrojUDnevniku = um.BrojUDnevniku;
            ucenik.Email = um.Email;
            ucenik.GodinaRodjenja = um.GodinaRodjenja;
            ucenik.Ime = um.Ime;
            ucenik.Prezime = um.Prezime;
            ucenik.Razred = um.Prezime;
            ucenik.Odeljenje = um.Odeljenje;
            ucenik.Telefon = um.Telefon;

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
            UcenikModel ucenik = bdb.Ucenik.Find(id);
            if (ucenik == null)
            {
                return HttpNotFound();
            }
            return View(ucenik);
        }

        // GET: Knjiga
        [HttpPost]
        public ActionResult Delete(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var ucenik = bdb.Ucenik.FirstOrDefault(a => a.UcenikID == id);

            bdb.Ucenik.Remove(ucenik);
            bdb.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var ucenik = bdb.Ucenik.FirstOrDefault(a => a.UcenikID == id);

            return View(ucenik);
        }
    }
}