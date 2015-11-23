using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.Models
{
    /// <summary>
    /// L'oggetto con i parametri di ricerca per le chiamate agli impianti
    /// </summary>
    public class OutboundCallsCriteria
    {
        public string Login { get; set; }
        public string CAP { get; set; }
        public string City { get; set; }
        public int DaysInFuture { get; set; }
        public string PlantClass { get; set; }
        public string PlantType { get; set; }


    }
}