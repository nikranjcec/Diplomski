using ApartmaniService.DTO;
using GostMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GostMVC.Controllers
{
    public class RezervacijeController : Controller
    {
        RezervacijeCRUDServis.RezervacijeCRUDServiceClient rezervacijeClient;
        ApartmaniCRUDServis.ApartmaniCRUDServiceClient apartmaniClient;

        public RezervacijeController()
        {
            rezervacijeClient = new RezervacijeCRUDServis.RezervacijeCRUDServiceClient();
            apartmaniClient = new ApartmaniCRUDServis.ApartmaniCRUDServiceClient();
        }
        // GET: Rezervacije
        public ActionResult Index()
        {
            if (Session["GostID"] != null)
            {
                int id = int.Parse(Session["GostID"].ToString());
                IEnumerable<RezervacijaDTO> listaRezervacija = rezervacijeClient.dohvatiRezervacijeZaGosta(id);
                return View(listaRezervacija);
            }
            else
            {
                return RedirectToAction("Prijava", "Gost");
            }
            
        }

        public ActionResult Nova()
        {
            int gostId = int.Parse(Session["GostID"].ToString());
            Common common = new Common();
            RezervacijaViewModel rvm = new RezervacijaViewModel();
            rvm.GostID = gostId;
            rvm.listaApartmana = common.dohvatiApartmane();
            rvm.ApartmanID = 0;
            return View ("Rezervacija",rvm);
        }

        public PartialViewResult Detalji(int id)
        {
            ApartmanDTO apartman = apartmaniClient.dohvatiApartmanID(id);
            return PartialView("Detalji", apartman);
        }

        public ActionResult Otkazi(int id)
        {
            bool otkazano = rezervacijeClient.otkaziRezervaciju(id);
            return RedirectToAction("Index");
        }
    }
}