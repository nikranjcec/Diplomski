using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApartmaniService.DTO
{
    [DataContract]
    public class ApartmanDTO
    {
        [DataMember]
        public int ApartmanID { get; set; }
        [DataMember]
        public string Naziv { get; set; }
        [DataMember]
        public string BrojOsoba { get; set; }
        [DataMember]
        public string Adresa { get; set; }
        [DataMember]
        public string Grad { get; set; }
        [DataMember]
        public int Povrsina { get; set; }
        [DataMember]
        public decimal Cijena { get; set; }
        //[DataMember]
        // public virtual ICollection<RezervacijaDTO> Rezervacija { get; set; }
    }
}