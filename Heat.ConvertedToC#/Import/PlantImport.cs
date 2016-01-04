using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.Import
{
    /// <summary>
    /// Un oggetto di ausilio per l'importazione dell'impianto.
    /// Mappa 1-a-1 la riga del file di testo da importare.
    /// </summary>
    public class PlantImport
    {
        public string GruppoImpianto { get; set; }
        public string SuffissoGruppo { get; set; }
        public int CodiceImpianto { get; set; }
        public string Nominativo { get; set; }
        public string IndirizzoImpianto { get; set; }
        public string NumeroCivico { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string ClasseImpianto { get; set; }
        public string TipologiaImpianto { get; set; }
        public string CodImpProvincia { get; set; }
public string Comune { get; set; }
        public string CAP { get; set; }
        public string Provincia { get; set; }
        public string Frazione { get; set; }
        public string Combustibile { get; set; }

    }
}