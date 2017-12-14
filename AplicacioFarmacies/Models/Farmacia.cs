using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacioFarmacies.Models
{
    public class Farmacia
    {
        public int IdFarmacia { get; set; }
        public string CodiFarmacia { get; set; }
        public string NomFarmacia { get; set; }
        public string TipusVia { get; set; }
        public string Carrer { get; set; }
        public int NumeroVia { get; set; }
        public string NumeroTelefon { get; set; }
        public string AreaBasicaSalut { get; set; }

        public int IdPoblacio { get; set; }
        public virtual Poblacio Poblacio { get; set; }
    }
}