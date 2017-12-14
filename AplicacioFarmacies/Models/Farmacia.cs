using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacioFarmacies.Models
{
    public class Farmacia
    {
        [Key]
        public int IdFarmacia { get; set; }
        [Display(Name = "Codi de la farmacia")]
        public string CodiFarmacia { get; set; }
        [Display(Name = "Nom de la farmacia")]
        public string NomFarmacia { get; set; }
        [Display(Name = "Tipus de via")]
        public string TipusVia { get; set; }
        [Display(Name = "Carrer")]
        public string Carrer { get; set; }
        [Display(Name = "Numero de via")]
        public int NumeroVia { get; set; }
        [Display(Name = "Numero de telèfon")]
        public string NumeroTelefon { get; set; }
        [Display(Name = "Area bàsica de salut")]
        public string AreaBasicaSalut { get; set; }

        [Display(Name = "Població")]
        public int IdPoblacio { get; set; }
        public virtual Poblacio Poblacio { get; set; }
    }
}