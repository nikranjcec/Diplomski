using ApartmaniMVC.Models;
using ApartmaniService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmaniMVC.Controllers
{
    public class ApartmaniController : Controller
    {
        ApartmaniCRUDServis.ApartmaniCRUDServiceClient client;
        RezervacijeCRUDServis.RezervacijeCRUDServiceClient rezervacijeClient;

        public ApartmaniController()
        {
            client = new ApartmaniCRUDServis.ApartmaniCRUDServiceClient();
            rezervacijeClient = new RezervacijeCRUDServis.RezervacijeCRUDServiceClient();
        }
        // GET: Apartmani
        public ActionResult Index()
        {
            IEnumerable<ApartmanDTO> listaApartmana = client.dohvatiListuApartmana();
            return View(listaApartmana);
        }

        public ActionResult Novi()
        {
            ApartmanViewModel noviApartman = new ApartmanViewModel();
            return View(noviApartman);
        }

        public ActionResult Spremi(ApartmanViewModel noviApartman)
        {
            ApartmanDTO apartmanZaUnos = new ApartmanDTO();

            apartmanZaUnos.Naziv = noviApartman.Naziv;
            apartmanZaUnos.Adresa = noviApartman.Adresa;
            apartmanZaUnos.Grad = noviApartman.Grad;
            apartmanZaUnos.Cijena = noviApartman.Cijena;
            apartmanZaUnos.Povrsina = noviApartman.Povrsina;
            apartmanZaUnos.BrojOsoba = noviApartman.BrojOsoba;

            if (noviApartman.ApartmanID != 0)
            {
                apartmanZaUnos.ApartmanID = noviApartman.ApartmanID;
                bool uredivanje = client.urediApartman(apartmanZaUnos);
            }
            else
            {
                bool unos = client.kreirajNoviApartman(apartmanZaUnos);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Uredi(int id)
        {
            ApartmanDTO apartman = client.dohvatiApartmanID(id);
            ApartmanViewModel apartmanZaUredivanje = new ApartmanViewModel();

            apartmanZaUredivanje.Naziv = apartman.Naziv;
            apartmanZaUredivanje.Cijena = apartman.Cijena;
            apartmanZaUredivanje.Povrsina = apartman.Povrsina;
            apartmanZaUredivanje.Grad = apartman.Grad;
            apartmanZaUredivanje.Adresa = apartman.Adresa;
            apartmanZaUredivanje.BrojOsoba = apartman.BrojOsoba;
            apartmanZaUredivanje.ApartmanID = apartman.ApartmanID;

            return View("Novi", apartmanZaUredivanje);
        }

        public PartialViewResult Detalji(int id)
        {
            IEnumerable<RezervacijaDTO> rezervacije = rezervacijeClient.dohvatiRezervacijeZaApartman(id);
            return PartialView("Detalji", rezervacije);
        }
    }
}