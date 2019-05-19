using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApartmaniService.DTO
{
    [DataContract]
    public class GostDTO
    {
        [DataMember]
        public int GostID { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Sifra { get; set; }
        [DataMember]
        public string Adresa { get; set; }
        [DataMember]
        public string Telefon { get; set; }
        //[DataMember]
        //public virtual ICollection<RezervacijaDTO> Rezervacija { get; set; }
    }
}