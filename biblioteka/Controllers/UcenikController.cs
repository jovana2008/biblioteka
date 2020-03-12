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

            bdb.Ucenik.Add(um);
            bdb.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}