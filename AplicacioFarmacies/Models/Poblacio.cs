using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacioFarmacies.Models
{
    public class Poblacio
    {
        public int IdPoblacio { get; set; }
        public string NomPoblacio { get; set; }
        public int CP { get; set; }

        public int IdProvincia { get; set; }
        public virtual Provincia Provincia { get; set; }

        public virtual List<Farmacia> Farmacies { get; set; }
    }
}