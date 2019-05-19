using ApartmaniService.DTO;
using GostMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GostMVC.Controllers
{
    public class GostController : Controller
    {
        RegistracijaCRUDServis.RegistracijaCRUDServiceClient client;

        public GostController()
        {
            client = new RegistracijaCRUDServis.RegistracijaCRUDServiceClient();
        }
        // GET: Gost
        public ActionResult Novi()
        {
            GostViewModel gost = new GostViewModel();
            return View(gost);
        }

        public ActionResult Spremi(GostViewModel gost)
        {
            GostDTO gostZaUnos = new GostDTO();

            gostZaUnos.Ime = gost.Ime;
            gostZaUnos.Prezime = gost.Prezime;
            gostZaUnos.Adresa = gost.Adresa;
            gostZaUnos.Telefon = gost.Telefon;
            gostZaUnos.Email = gost.Email;
            gostZaUnos.Sifra = gost.Sifra;

           

            if (gost.GostID > 0)
            {
                gostZaUnos.GostID = gost.GostID;
                bool promjena = client.uredivanjePodataka(gostZaUnos);

                if (promjena)
                {
                    if (Session["GostID"] != null)
                    {
                        Session["Email"] = gost.Email; 
                    }
                    return View("Novi", gost);
                    
                }
                else
                {
                    return View("Novi", gost);
                }
            }
            else
            {
                bool unos = client.novaRegistracija(gostZaUnos);

                if (unos)
                {
                    return View("Prijava");
                }
                else
                {
                    return View("Novi", gost);
                }
            }

           
            
        }

        [HttpPost]
        public ActionResult Prijava(GostViewModel gost)
        {
            GostDTO prijavljeniGost = new GostDTO();

            prijavljeniGost = client.prijava(gost.Email, gost.Sifra);

            if (prijavljeniGost != null)
            {
                Session["GostID"] = prijavljeniGost.GostID;
                Session["Email"] = prijavljeniGost.Email;
                return RedirectToAction("Index", "Apartmani");
            }
            else
            {
                gost.ErrorMessage = "Prijava nije uspjela, pokušajte ponovno.";
                return View("Prijava", gost);
            }
        }

        [HttpGet]
        public ActionResult Prijava()
        {
            GostViewModel gost = new GostViewModel();
            return View("Prijava", gost);
        }

        public ActionResult LogOff(string GostID)
        {
            Session["GostID"] = null;
            Session["Email"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Uredi(string GostID)
        {
            GostViewModel gost = new GostViewModel();
            GostDTO gostID = client.gostID(GostID);
            
            if (gostID != null)
            {
                gost.Ime = gostID.Ime;
                gost.Prezime = gostID.Prezime;
                gost.Adresa = gostID.Adresa;
                gost.Email = gostID.Email;
                gost.Telefon = gostID.Telefon;
                gost.Sifra = gostID.Sifra;
                gost.GostID = gostID.GostID;
            }
            return View("Novi", gost);
        }
    }
}