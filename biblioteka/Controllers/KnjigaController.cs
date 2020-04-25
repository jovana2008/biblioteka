using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //[Route("knjiga")]
    public class KnjigaController : Controller
    {

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(KnjigaModel km)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var knjiga = new KnjigaModel();

            knjiga.MestoIzdavanja = km.MestoIzdavanja;
            knjiga.InventarniBroj = km.InventarniBroj;
            knjiga.Naslov = km.Naslov;
            knjiga.Pisac = km.Pisac;
            knjiga.GodinaIzdavanja = km.GodinaIzdavanja;

            bdb.Knjiga.Add(knjiga);

            bdb.SaveChanges();


            return RedirectToAction("Index");
        }











        // GET: Knjiga
        [HttpGet]
        public ActionResult Index()
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var ucenik = bdb.Ucenik.ToList();

            return View(ucenik);
        }










        // GET: Knjiga/Izmeni/5
        //[Route("{knjigaId}")]
        public ActionResult Izmeni(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var knjiga = bdb.Knjiga.FirstOrDefault(a => a.KnjigaId == id);

            var zanrovi = bdb.Zanr.ToList();

            var listaZanrova = new List<SelectListItem>();

            zanrovi.ForEach(z => {

                listaZanrova.Add(new SelectListItem() { Text = z.Naziv, Value = z.Id.ToString(), Selected = z.Id == knjiga.ZanrId ? true : false });
            });

            ViewBag.ListaZanrova = listaZanrova;

            return View(knjiga);
        }

        [HttpPost]
        public ActionResult Izmeni(KnjigaModel km)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var knjiga = bdb.Knjiga.FirstOrDefault(a => a.KnjigaId == km.KnjigaId);

            knjiga.MestoIzdavanja = km.MestoIzdavanja;
            knjiga.InventarniBroj = km.InventarniBroj;
            knjiga.Naslov = km.Naslov;
            knjiga.Pisac = km.Pisac;
            knjiga.GodinaIzdavanja = km.GodinaIzdavanja;
            knjiga.ZanrId = km.ZanrId;

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
            KnjigaModel knjiga = bdb.Knjiga.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // GET: Knjiga
        [HttpPost]
        public ActionResult Delete(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();

            var knjiga = bdb.Knjiga.FirstOrDefault(a => a.KnjigaId == id);

            bdb.Knjiga.Remove(knjiga);
            bdb.SaveChanges();

            return RedirectToAction("Index");
        }




        public ActionResult Details(int id)
        {
            BibliotekaDB bdb = new BibliotekaDB();
            var knjiga = bdb.Knjiga.FirstOrDefault(a => a.KnjigaId == id);

            return View(knjiga);
        }
    }
}
