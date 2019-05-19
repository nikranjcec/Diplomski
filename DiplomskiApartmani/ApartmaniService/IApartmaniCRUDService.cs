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
    public interface IApartmaniCRUDService
    {
        [OperationContract]
        IEnumerable<ApartmanDTO> dohvatiListuApartmana();

        [OperationContract]
        bool kreirajNoviApartman(ApartmanDTO noviApartman);

        [OperationContract]
        ApartmanDTO dohvatiApartmanID(int id);

        [OperationContract]
        bool urediApartman(ApartmanDTO apartman);
    }
}
