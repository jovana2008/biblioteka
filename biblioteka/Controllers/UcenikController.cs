using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UcenikController : Controller
    {
        // GET: Ucenik
        [HttpGet]
        public ActionResult Index()
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var ucenik = bdb.Ucenik.ToList();

            return View(ucenik);
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

            ucenik.Ime = um.Ime;
            ucenik.UcenikID = um.UcenikID;
            ucenik.Prezime = um.Prezime;
            ucenik.GodinaRodjenja = um.GodinaRodjenja;
            ucenik.BrojUDnevniku = um.BrojUDnevniku;
            ucenik.Razred = um.Razred;
            ucenik.Odeljenje = um.Odeljenje;
            ucenik.Adresa = um.Adresa;
            ucenik.Email = um.Email;
            ucenik.Telefon = um.Telefon;




            bdb.Ucenik.Add(ucenik);
            
            bdb.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}