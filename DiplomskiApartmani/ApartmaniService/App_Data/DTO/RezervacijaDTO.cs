using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApartmaniService.DTO

{
    [DataContract]
    public class RezervacijaDTO
    {
        [DataMember]
        public int RezervacijaID { get; set; }
        [DataMember]
        public int GostID { get; set; }
        [DataMember]
        public int ApartmanID { get; set; }
        [DataMember]
        public System.DateTime Od { get; set; }
        [DataMember]
        public System.DateTime Do { get; set; }
        [DataMember]
        public short Status { get; set; }
        [DataMember]
        public string ImeGosta { get; set; }
        [DataMember]
        public string PrezimeGosta { get; set; }
        [DataMember]
        public string NazivApartmana { get; set; }

        //[DataMember]
        //public virtual ApartmanDTO Apartman { get; set; }
        //[DataMember]
        //public virtual GostDTO Gost { get; set; }
    }
}