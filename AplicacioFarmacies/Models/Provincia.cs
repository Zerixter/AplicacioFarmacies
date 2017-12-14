using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacioFarmacies.Models
{
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }
        [Display(Name = "Nom de la provincia")]
        public string NomProvincia { get; set; }

        public virtual List<Poblacio> Poblacions { get; set } = new List<Poblacio>();
    }
}