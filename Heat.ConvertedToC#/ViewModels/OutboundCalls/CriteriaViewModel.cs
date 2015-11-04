using System.Collections.Generic;
using System.Web.Mvc;

namespace Heat.ViewModels.OutboundCalls
{
    public class CriteriaViewModel
    {
        public string SelectedCAP { get; set; } 
        public string SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CAPList { get; set; }
        public List<SelectListItem> CityList { get; set; }

    }
}