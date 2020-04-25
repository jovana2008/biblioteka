using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ZanrController : Controller
    {
        // GET: Zanr
        public ActionResult Index()
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var zanrovi = bdb.Zanr.ToList();


            return View(zanrovi);
        }

        // GET: Zanr/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Zanr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zanr/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zanr/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Zanr/Edit/5
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

        // GET: Zanr/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Zanr/Delete/5
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
