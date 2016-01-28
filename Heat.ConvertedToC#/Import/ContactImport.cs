using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.Import
{
    public class ContactImport
    {
        public string Descrizione { get; set; }
        public string Nominativo { get; set; }
        public string Ruolo { get; set; }
        public string Indirizzo { get; set; }
        public string Civico { get; set; }
        public string Comune { get; set; }
        public string CAP { get; set; }
        public string Provincia { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Email { get; set; }
        public string PIVA { get; set; }
        public int CodiceImpianto { get; set; }
    }
}
