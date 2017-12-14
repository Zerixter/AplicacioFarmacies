using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace AplicacioFarmacies.Models
{

    public class Test: DbContext
    {
        public DbSet<Provincia> Provincies { get; set; }
        public DbSet<Poblacio> Poblacions { get; set; }
        public DbSet<Farmacia> Farmacies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Poblacio>()
                .HasRequired(r => r.Provincia)
                .WithMany(m => m.Poblacions)
                .HasForeignKey(k => k.IdProvincia)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Farmacia>()
                .HasRequired(r => r.Poblacio)
                .WithMany(m => m.Farmacies)
                .HasForeignKey(k => k.IdPoblacio)
                .WillCascadeOnDelete(true);
        }
    }
}

