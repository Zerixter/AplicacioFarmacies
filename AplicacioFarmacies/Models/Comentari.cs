using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacioFarmacies.Models
{
    public class Comentari
    {
        [Key]
        public int IdComentari { get; set; }
        [Display(Name = "Nom del autor del comentari")]
        public string NomAutorComentari { get; set; }
        [Display(Name = "Contingut del comentari")]
        public string ContingutComentari { get; set; }

        [Display(Name = "Farmacia")]
        public int IdFarmacia { get; set; }
        public virtual Farmacia Farmacia { get; set; }
    }
}