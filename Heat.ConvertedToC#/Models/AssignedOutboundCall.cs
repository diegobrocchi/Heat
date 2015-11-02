using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Heat.Models
{
    public class AssignedOutboundCall
    {
        public int ID {get; set;}
        public string User {get; set;}
        public DateTime AssignmentDate {get; set;}
        public string ContactName { get; set; }

    }
}