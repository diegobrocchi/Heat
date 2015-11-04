using System.Collections.Generic;
using System.Web.Mvc;

namespace Heat.ViewModels.OutboundCalls
{
    public class CriteriaViewModel
    {
        public string SelectedCAP { get; set; } 
        public IEnumerable<SelectListItem> CAPList { get; set; }
        public string SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }
        
        public int DaysInFuture { get; set; }
        
    }
}