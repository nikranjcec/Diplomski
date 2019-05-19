using ApartmaniService.DTO;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ApartmaniService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RezervacijeCRUDService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RezervacijeCRUDService.svc or RezervacijeCRUDService.svc.cs at the Solution Explorer and start debugging.
    public class RezervacijeCRUDService : IRezervacijeCRUDService
    {
        public IEnumerable<RezervacijaDTO> dohvatiNepotvrdeneRezervacije()
        {
            List<RezervacijaDTO> listaRezervacija = dohvatiRezervacije();

            return listaRezervacija.Where(r => r.Status == 0).ToList();
        }

        private List<RezervacijaDTO> dohvatiRezervacije()
        {
            List<RezervacijaDTO> listaRezervacija = new List<RezervacijaDTO>();
            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                listaRezervacija = (from r in con.Rezervacija
                                    join a in con.Apartman on r.ApartmanID equals a.ApartmanID
                                    join g in con.Gost on r.GostID equals g.GostID
                                    select new RezervacijaDTO
                                    {
                                        GostID = g.GostID,
                                        ImeGosta = g.Ime,
                                        PrezimeGosta = g.Prezime,

                                        ApartmanID = a.ApartmanID,
                                        NazivApartmana = a.Naziv,

                                        RezervacijaID = r.RezervacijaID,
                                        Od = r.Od,
                                        Do = r.Do,
                                        Status = r.Status

                                    }).ToList();
            }

            return listaRezervacija;
        }

        public List<RezervacijaDTO> dohvatiRezervacijeZaApartman(int apartmanID)
        {
            List<RezervacijaDTO> listaRezervacija = dohvatiRezervacije();

            return listaRezervacija.Where(a => a.ApartmanID == apartmanID).ToList();
        }

        public List<RezervacijaDTO> dohvatiRezervacijeZaGosta(int gostID)
        {
            List<RezervacijaDTO> listaRezervacija = dohvatiRezervacije();

            return listaRezervacija.Where(g => g.GostID == gostID).ToList();
        }

        public bool kreirajNovuRezervaciju(RezervacijaDTO novaRezervacija)
        {
            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                bool unos = false;
                Rezervacija rezervacijaZaUnos = new Rezervacija();

                try
                {
                    rezervacijaZaUnos.ApartmanID = novaRezervacija.ApartmanID;
                    rezervacijaZaUnos.GostID = novaRezervacija.GostID;
                    rezervacijaZaUnos.Od = novaRezervacija.Od;
                    rezervacijaZaUnos.Do = novaRezervacija.Do;
                    rezervacijaZaUnos.Status = 0;

                    con.Rezervacija.Add(rezervacijaZaUnos);
                    con.SaveChanges();

                    unos = true;

                    return unos;
                }
                catch (Exception)
                {
                    unos = false;
                    return unos;
                }
                
            }
        }

        public bool promijeniStatusRezervacije(int rezervacijaID, int status)
        {
            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                bool promjena = false;

                try
                {
                    Rezervacija rezervacijaZaPromjenu = con.Rezervacija.Where(r => r.RezervacijaID == rezervacijaID).SingleOrDefault();

                    RezervacijaDTO rezervacija = new RezervacijaDTO();
                    rezervacija.ApartmanID = rezervacijaZaPromjenu.ApartmanID;
                    rezervacija.Od = rezervacijaZaPromjenu.Od;
                    rezervacija.Do = rezervacijaZaPromjenu.Do;

                    bool dostupno = provjeriDostupnost(rezervacija);

                    if (dostupno)
                    {
                        rezervacijaZaPromjenu.Status = short.Parse(status.ToString());
                        con.SaveChanges();

                        promjena = true;
                    }
                    else
                    {
                        promjena = false;
                    }

                    return promjena;
                }
                catch (Exception)
                {
                    promjena = false;
                    return promjena;
                }
            }
        }

        public bool provjeriDostupnost(RezervacijaDTO rezervacija)
        {
            bool dostupno = false;
            List<RezervacijaDTO> listaRezervacija = dohvatiRezervacije().Where(r => r.ApartmanID == rezervacija.ApartmanID && r.Status == 1).ToList();

            TimeRange intervalNoveRezervacije = new TimeRange(rezervacija.Od, rezervacija.Do);

            foreach(RezervacijaDTO r in listaRezervacija)
            {
                TimeRange intervalPostojećeRezervacije = new TimeRange(r.Od, r.Do);
                bool relacija = intervalNoveRezervacije.IntersectsWith(intervalPostojećeRezervacije);

                if (relacija)
                {
                    dostupno = false;
                    break;
                }
                else
                {
                    dostupno = true;
                }

            }
                
            return dostupno;
        }

        public bool otkaziRezervaciju(int rezervacijaID)
        {
            bool otkazano = false;
            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                try
                {
                    Rezervacija rezervacija = con.Rezervacija.Where(r => r.RezervacijaID == rezervacijaID).FirstOrDefault();
                    con.Rezervacija.Remove(rezervacija);
                    con.SaveChanges();

                    otkazano = true;
                }
                catch (Exception)
                {
                    otkazano = false;
                }
                
            }

            return otkazano;
        }
    }
}
