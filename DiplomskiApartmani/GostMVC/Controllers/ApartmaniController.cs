using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmaniService.DTO;
using GostMVC.Models;

namespace GostMVC.Controllers
{
    public class ApartmaniController : Controller
    {
        ApartmaniCRUDServis.ApartmaniCRUDServiceClient apartmaniClient;
        RezervacijeCRUDServis.RezervacijeCRUDServiceClient rezervacijeClient;

        public ApartmaniController()
        {
            apartmaniClient = new ApartmaniCRUDServis.ApartmaniCRUDServiceClient();
            rezervacijeClient = new RezervacijeCRUDServis.RezervacijeCRUDServiceClient();
        }
        // GET: Apartmani
        public ActionResult Index()
        {
            if (Session["GostID"] != null)
            {
                IEnumerable<ApartmanDTO> listaApartmana = apartmaniClient.dohvatiListuApartmana();
                return View(listaApartmana);
            }
            else
            {
                return RedirectToAction("Prijava", "Gost");
            }
            
        }

        public ActionResult Rezervacija(int apartmanID)
        {
            int gostID = int.Parse(Session["GostID"].ToString());
            Common common = new Common();
            RezervacijaViewModel novaRezervacija = new RezervacijaViewModel();

            novaRezervacija.ApartmanID = apartmanID;
            novaRezervacija.GostID = gostID;
            novaRezervacija.listaApartmana = common.dohvatiApartmane();
            return View(novaRezervacija);
        }

        public ActionResult Spremi(RezervacijaViewModel novaRezervacija)
        {
            int gostID = int.Parse(Session["GostID"].ToString());
            RezervacijaDTO rezervacijaZunos = new RezervacijaDTO();
            rezervacijaZunos.ApartmanID = novaRezervacija.ApartmanID;
            rezervacijaZunos.GostID = gostID;
            rezervacijaZunos.Od = novaRezervacija.Od;
            rezervacijaZunos.Do = novaRezervacija.Do;

            bool dostupno = rezervacijeClient.provjeriDostupnost(rezervacijaZunos);

            if (dostupno)
            {
                bool unos = rezervacijeClient.kreirajNovuRezervaciju(rezervacijaZunos);
                return RedirectToAction("Index", "Rezervacije");
            }
            else
            {
                novaRezervacija.ErrorMessage = "Apartman nije dostupan za rezervaciu!";
                return View("Rezervacija", novaRezervacija);
            }
            

            
        }

        public IEnumerable<SelectListItem> dohvatiApartmane()
        {
            IEnumerable<ApartmanDTO> listaApartmana = apartmaniClient.dohvatiListuApartmana();

            var apartmani = listaApartmana
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ApartmanID.ToString(),
                                    Text = x.Naziv
                                }).ToList();

            return new SelectList(apartmani, "Value", "Text");
        }
    }
}