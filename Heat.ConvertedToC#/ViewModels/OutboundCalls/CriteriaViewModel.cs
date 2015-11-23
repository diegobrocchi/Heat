using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Heat.ViewModels.OutboundCalls
{
    public class CriteriaViewModel
    {
        [Display(Name="CAP")]
        public string SelectedCAP { get; set; } 
        public IEnumerable<SelectListItem> CAPList { get; set; }

        [Display(Name="Città")]
        public string SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }

        [Display(Name = "Classe impianto")]
        public string PlantClassSelected { get; set; }
        public IEnumerable<SelectListItem> PlantClassList { get; set; }

        [Display(Name = "Tipo impianto")]
        public string PlantTypeSelected { get; set; }
        public IEnumerable<SelectListItem> PlantTypeList { get; set; }  

        [Display(Name="Giorni nel futuro")]
        public int DaysInFuture { get; set; }
        
    }
}