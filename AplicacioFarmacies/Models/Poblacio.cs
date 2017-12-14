using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacioFarmacies.Models
{
    public class Poblacio
    {
        [Key]
        public int IdPoblacio { get; set; }
        [Display(Name = "Nom de la població")]
        public string NomPoblacio { get; set; }
        [Display(Name = "Codi postal")]
        public int CP { get; set; }

        [Display(Name = "Provincia")]
        public int IdProvincia { get; set; }
        public virtual Provincia Provincia { get; set; }

        public virtual List<Farmacia> Farmacies { get; set; }
    }
}