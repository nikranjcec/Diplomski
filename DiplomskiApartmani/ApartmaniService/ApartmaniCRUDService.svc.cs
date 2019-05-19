using ApartmaniService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ApartmaniService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ApartmaniCRUDService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ApartmaniCRUDService.svc or ApartmaniCRUDService.svc.cs at the Solution Explorer and start debugging.
    public class ApartmaniCRUDService : IApartmaniCRUDService
    {
        public ApartmanDTO dohvatiApartmanID(int id)
        {
            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                return con.Apartman.Select(a => new ApartmanDTO
                {
                    Naziv = a.Naziv,
                    Cijena = a.Cijena,
                    BrojOsoba = a.BrojOsoba,
                    Povrsina = a.Povrsina,
                    Adresa = a.Adresa,
                    Grad = a.Grad,
                    ApartmanID = a.ApartmanID
                }).Where(ap => ap.ApartmanID == id).SingleOrDefault();
            }
        }

        public IEnumerable<ApartmanDTO> dohvatiListuApartmana()
        {
            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                return con.Apartman.Select(a => new ApartmanDTO
                {
                    ApartmanID = a.ApartmanID,
                    Naziv = a.Naziv,
                    Grad = a.Grad,
                    Adresa = a.Adresa,
                    Povrsina = a.Povrsina,
                    BrojOsoba = a.BrojOsoba,
                    Cijena = a.Cijena
                }).ToList();
            }
        }

        public bool kreirajNoviApartman(ApartmanDTO noviApartman)
        {
            bool unosUspio = true;

            using (ApartmaniEntities con = new ApartmaniEntities())
            {

                Apartman apartmanZaUnos = new Apartman();

                try
                {
                    apartmanZaUnos.Naziv = noviApartman.Naziv;
                    apartmanZaUnos.Adresa = noviApartman.Adresa;
                    apartmanZaUnos.Grad = noviApartman.Grad;
                    apartmanZaUnos.Cijena = noviApartman.Cijena;
                    apartmanZaUnos.Povrsina = noviApartman.Povrsina;
                    apartmanZaUnos.BrojOsoba = noviApartman.BrojOsoba;

                    con.Apartman.Add(apartmanZaUnos);
                    con.SaveChanges();

                    unosUspio = true;
                }
                catch (Exception ex)
                {
                    unosUspio = false;
                    return unosUspio;
                }


            };

            return unosUspio;
        }

        public bool urediApartman(ApartmanDTO apartman)
        {
            bool uredivanje = false;

            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                try
                {
                    Apartman apartmanZaUredivanje = con.Apartman.
                            SingleOrDefault(a => a.ApartmanID == apartman.ApartmanID);

                    if (apartmanZaUredivanje != null)
                    {
                        apartmanZaUredivanje.Naziv = apartman.Naziv;
                        apartmanZaUredivanje.Cijena = apartman.Cijena;
                        apartmanZaUredivanje.Povrsina = apartman.Povrsina;
                        apartmanZaUredivanje.Grad = apartman.Grad;
                        apartmanZaUredivanje.Adresa = apartman.Adresa;
                        apartmanZaUredivanje.BrojOsoba = apartman.BrojOsoba;

                        con.SaveChanges();

                        uredivanje = true;
                    }
                    else
                    {
                        uredivanje = false;
                    }
                }
                catch (Exception)
                {
                    uredivanje = false;
                    return uredivanje;
                }

            }

            return uredivanje;
        }
    }
}
