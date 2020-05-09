using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PozajmiceController : Controller
    {
        // GET: Pozajmice
        public ActionResult Index()
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var pozajmice = bdb.Pozajmice.ToList();
            
            return View(pozajmice);
        }

        // GET: Pozajmice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pozajmice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pozajmice/Create
        [HttpPost]
        public ActionResult Create(PozajmiceModel pm)
        {
            try
            {
                // TODO: Add insert logic here
                BibliotekaDB bdb = new BibliotekaDB();
                var pozajmica = new PozajmiceModel();

                pozajmica.UcenikId = pm.UcenikId;
                pozajmica.KnjigaId = pm.KnjigaId;
                pozajmica.DatumPozajmice = pm.DatumPozajmice;

                bdb.Pozajmice.Add(pozajmica);

                bdb.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pozajmice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pozajmice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pozajmice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pozajmice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
