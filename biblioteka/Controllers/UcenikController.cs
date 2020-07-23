using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;

namespace WebApplication1.Controllers
{
    public class UcenikController : Controller
    {
        // GET: Ucenik
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            BibliotekaDB bdb = new BibliotekaDB();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PrezimeSortParm = String.IsNullOrEmpty(sortOrder) ? "prezime_desc" : "";
            ViewBag.BrojSortParm = String.IsNullOrEmpty(sortOrder) ? "broj_desc" : "";
            ViewBag.RazredSortParm = String.IsNullOrEmpty(sortOrder) ? "razred_desc" : "";
            ViewBag.OdeljenjeSortParm = String.IsNullOrEmpty(sortOrder) ? "odeljenje_desc" : "";
            ViewBag.GodinaSortParm = sortOrder == "Godina" ? "godina_desc" : "Godina";
            var ucenici = from u in bdb.Ucenik
                         select u;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                ucenici = ucenici.Where(u => u.Ime.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ucenici = ucenici.OrderByDescending(u => u.Ime);
                    break;
                case "prezime_desc":
                    ucenici = ucenici.OrderByDescending(u => u.Prezime);
                    break;
                case "broj_desc":
                    ucenici = ucenici.OrderByDescending(u => u.BrojUDnevniku);
                    break;
                case "razred_desc":
                    ucenici = ucenici.OrderByDescending(u => u.Razred);
                    break;
                case "odeljenje_desc":
                    ucenici = ucenici.OrderByDescending(u => u.Odeljenje);
                    break;
                case "Godina":
                    ucenici = ucenici.OrderBy(u => u.GodinaRodjenja);
                    break;
                case "godina_desc":
                    ucenici = ucenici.OrderByDescending(u => u.GodinaRodjenja);
                    break;
                default:
                    ucenici = ucenici.OrderBy(u => u.Ime);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ucenici.ToPagedList(pageNumber, pageSize));
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
            ucenik.Razred = um.Razred;
            ucenik.Odeljenje = um.Odeljenje;
            ucenik.Telefon = um.Telefon;

            bdb.Ucenik.Add(ucenik);

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