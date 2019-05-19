using ApartmaniService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ApartmaniService
{
    [ServiceContract]
    public interface IRegistracijaCRUDService
    {
        [OperationContract]
        bool novaRegistracija(GostDTO noviGost);
        [OperationContract]
        bool uredivanjePodataka(GostDTO gostZaUredivanje);
        [OperationContract]
        GostDTO prijava(string email, string sifra);
        [OperationContract]
        GostDTO gostID(string GostID);
    }
}
