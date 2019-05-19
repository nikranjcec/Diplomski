using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmaniMVC.Models
{
    public class RezervacijaViewModel
    {
        public int RezervacijaID { get; set; }
        public int GostID { get; set; }
        public int ApartmanID { get; set; }
        public System.DateTime Od { get; set; }
        public System.DateTime Do { get; set; }
        public short Status { get; set; }
        public string ImeGosta { get; set; }
        public string PrezimeGosta { get; set; }
        public string NazivApartmana { get; set; }
    }
}