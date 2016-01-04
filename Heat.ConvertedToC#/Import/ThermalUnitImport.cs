using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.Import
{
    /// <summary>
    /// Un oggetto di ausilio che mappa le riga del file di import per le caldaie.
    /// </summary>
    public class ThermalUnitImport
    {
         public int CodiceImpianto { get; set; }
        public string Nominativo { get; set; }
        public string Indirizzo { get; set; }
        public string Civico { get; set; }
        public string Comune { get; set; }
        public string CAP { get; set; }
        public string Marca { get; set; }
        public string ModelloCaldaia { get; set; }
        public string MatricolaCaldaia { get; set; }
        public string UbicazioneCaldaia { get; set; }
        public DateTime? DataPrimaAccensione { get; set; }
        public DateTime? DataInstallazione { get; set; }
        public int AnnoCostruzione { get; set; }
        public string CodiceProduttoreCaldaia { get; set; }
        public Single PotenzaNominaleKW { get; set; }
        public Single PortataTermica { get; set; }
        public Single Rendimento { get; set; }
        public string DescrizioneGaranzia { get; set; }
        public string MarcaBruciatore { get; set; }
        public string ModelloBruciatore { get; set; }
        public string MatricolaBruciatore { get; set; }
        public DateTime? DataPrimaAccensioneBruciatore { get; set; }
        public int AnnoCostruzioneBruciatore { get; set; }
        public string CodiceProduttoreBruciatore { get; set; }
        public Single PotenzaMinimaBruciatore { get; set; }
        public Single PotenzaMassimaBruciatore { get; set; }
        public string TipoGaranziaBruciatore { get; set; }
    }
}