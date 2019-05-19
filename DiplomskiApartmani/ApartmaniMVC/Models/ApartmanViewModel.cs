using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ApartmaniMVC.Models
{
    public class ApartmanViewModel
    {
        public int ApartmanID { get; set; }
        [DisplayName("Naziv")]
        public string Naziv { get; set; }
        [DisplayName("Broj osoba")]
        public string BrojOsoba { get; set; }
        [DisplayName("Adresa")]
        public string Adresa { get; set; }
        [DisplayName("Grad")]
        public string Grad { get; set; }
        [DisplayName("Površina")]
        public int Povrsina { get; set; }
        [DisplayName("Cijena")]
        public decimal Cijena { get; set; }
    }
}