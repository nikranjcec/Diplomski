using System.Web.Mvc;
using System.Collections.Generic;
using ApartmaniService.DTO;

namespace ApartmaniMVC.Controllers
{
    public class RezervacijaController : Controller
    {
        RezervacijeCRUDServis.RezervacijeCRUDServiceClient client;

        public RezervacijaController()
        {
            client = new RezervacijeCRUDServis.RezervacijeCRUDServiceClient();
        }
        // GET: Rezervacija
        public ActionResult Index()
        {
            IEnumerable<RezervacijaDTO> listaRezervacija = client.dohvatiNepotvrdeneRezervacije();
            return View(listaRezervacija);
        }

        public ActionResult Potvrdi (int rezervacijaID)
        {
            bool promjena = client.promijeniStatusRezervacije(rezervacijaID, 1);
            return RedirectToAction("Index");
        }

        public ActionResult Odbi(int rezervacijaID)
        {
            bool promjena = client.promijeniStatusRezervacije(rezervacijaID, 2);
            return RedirectToAction("Index");
        }
    }
}