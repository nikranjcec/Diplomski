using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GostMVC.Models
{
    public class RezervacijaViewModel
    {
        public int RezervacijaID { get; set; }
        public int GostID { get; set; }
        public int ApartmanID { get; set; }
        public IEnumerable<SelectListItem> listaApartmana { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Od { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Do { get; set; }
        public short Status { get; set; }
        public string ImeGosta { get; set; }
        public string PrezimeGosta { get; set; }
        public string NazivApartmana { get; set; }
        public string ErrorMessage { get; set; }
    }
}