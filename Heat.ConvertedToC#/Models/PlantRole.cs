using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heat.Models
{
    /// <summary>
    /// Rappresenta il ruolo che un contatto ha relativamente ad un impianto (proprietario, conduttore,..)
    /// </summary>
    public class PlantRole
    {
        public int ID { get; set; }
        public string Role { get; set; }
    }
}