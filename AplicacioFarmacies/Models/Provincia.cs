using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacioFarmacies.Models
{
    public class Provincia
    {
        public int IdProvincia { get; set; }
        public string NomProvincia { get; set; }

        public virtual List<Poblacio> Poblacions { get; set; } = new List<Poblacio>();
    }
}