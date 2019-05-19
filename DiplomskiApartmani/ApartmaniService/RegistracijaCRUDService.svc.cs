using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApartmaniService.DTO;

namespace ApartmaniService
{
    public class RegistracijaCRUDService : IRegistracijaCRUDService
    {
        public GostDTO gostID(string GostID)
        {
            int id = int.Parse(GostID);
            GostDTO gost = new GostDTO();
            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                Gost gostID = con.Gost.SingleOrDefault(g => g.GostID == id);

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
            }

            return gost;
        }

        public bool novaRegistracija(GostDTO noviGost)
        {
            bool unos = false;

            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                try
                {
                    Gost gostZaUnos = new Gost();

                    gostZaUnos.Ime = noviGost.Ime;
                    gostZaUnos.Prezime = noviGost.Prezime;
                    gostZaUnos.Adresa = noviGost.Adresa;
                    gostZaUnos.Email = noviGost.Email;
                    gostZaUnos.Sifra = noviGost.Sifra;
                    gostZaUnos.Telefon = noviGost.Telefon;

                    con.Gost.Add(gostZaUnos);
                    con.SaveChanges();

                    unos = true;

                    return unos;
                }
                catch (Exception)
                {
                    return unos;
                }
                
            }
        }

        public GostDTO prijava(string email, string sifra)
        {
            Gost prijavljeniGost;

            GostDTO gost = new GostDTO();

            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                prijavljeniGost = con.Gost.Where(g => g.Email == email && g.Sifra == sifra).SingleOrDefault();

                if (prijavljeniGost != null)
                {
                    gost.Ime = prijavljeniGost.Ime;
                    gost.Prezime = prijavljeniGost.Prezime;
                    gost.Adresa = prijavljeniGost.Adresa;
                    gost.Email = prijavljeniGost.Email;
                    gost.Sifra = prijavljeniGost.Sifra;
                    gost.Telefon = prijavljeniGost.Telefon;
                    gost.GostID = prijavljeniGost.GostID;
                }
                else
                {
                    gost = null;
                }
            }

            return gost;
        }

        public bool uredivanjePodataka(GostDTO gostZaUredivanje)
        {
            bool uredivanje = false;
            Gost gost;
            using (ApartmaniEntities con = new ApartmaniEntities())
            {
                try
                {
                    gost = con.Gost.SingleOrDefault(g => g.GostID == gostZaUredivanje.GostID);

                    if (gost != null)
                    {
                        gost.Ime = gostZaUredivanje.Ime;
                        gost.Prezime = gostZaUredivanje.Prezime;
                        gost.Adresa = gostZaUredivanje.Adresa;
                        gost.Telefon = gostZaUredivanje.Telefon;
                        gost.Email = gostZaUredivanje.Email;
                        gost.Sifra = gostZaUredivanje.Sifra;

                        con.SaveChanges();

                        uredivanje = true;

                        return uredivanje;
                    }
                    else
                    {
                        return uredivanje;
                    }
                }
                catch (Exception)
                {
                    return uredivanje;
                }
            }
        }


    }
}
