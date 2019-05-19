using ApartmaniService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ApartmaniService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRezervacijeCRUDService" in both code and config file together.
    [ServiceContract]
    public interface IRezervacijeCRUDService
    {
        [OperationContract]
        IEnumerable<RezervacijaDTO> dohvatiNepotvrdeneRezervacije();
        [OperationContract]
        List<RezervacijaDTO> dohvatiRezervacijeZaApartman(int apartmanID);
        [OperationContract]
        List<RezervacijaDTO> dohvatiRezervacijeZaGosta(int gostID);
        [OperationContract]
        bool kreirajNovuRezervaciju(RezervacijaDTO novaRezervacija);
        [OperationContract]
        bool promijeniStatusRezervacije(int rezervacijaID, int status);
        [OperationContract]
        bool provjeriDostupnost(RezervacijaDTO rezervacija);
        [OperationContract]
        bool otkaziRezervaciju(int rezervacijaID);

    }
}
