using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heat.Models;

namespace Heat.Manager
{
    public class ProposedOutBoundCallDTO
    {
        /// <summary>
        /// L'utente a cui è stata proposta la chiamata.
        /// </summary>
        /// <returns></returns>
        public string User { get; set; }
        public int PlantID { get; set; }
        public string PlantRegionalID { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string MainPhoneNumber { get; set; }
        //public List<string> TelephoneNumbers { get; set; }

    }
}
