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
        public string ContactName { get; set; }
        public string TelephoneNumber { get; set; }

    }
}
