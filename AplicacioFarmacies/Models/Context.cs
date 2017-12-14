using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AplicacioFarmacies.Models
{

    public class Test: DbContext
    {
        public DbSet<Provincia> Provincies { get; set; }
        public DbSet<Poblacio> Poblacions { get; set; }
        public DbSet<Farmacia> Farmacies { get; set; }
    }
}

