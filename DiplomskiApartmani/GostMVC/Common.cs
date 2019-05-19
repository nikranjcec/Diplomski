using ApartmaniService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GostMVC
{
    public class Common
    {
        ApartmaniCRUDServis.ApartmaniCRUDServiceClient apartmaniClient;

        public Common()
        {
            apartmaniClient = new ApartmaniCRUDServis.ApartmaniCRUDServiceClient();
        }

       public IEnumerable<SelectListItem> dohvatiApartmane()
        {
            IEnumerable<ApartmanDTO> listaApartmana = apartmaniClient.dohvatiListuApartmana();

            var apartmani = listaApartmana
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ApartmanID.ToString(),
                                    Text = x.Naziv
                                }).ToList();

            return new SelectList(apartmani, "Value", "Text");
        }
    }
}