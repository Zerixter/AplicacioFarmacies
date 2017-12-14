namespace AplicacioFarmacies.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AplicacioFarmacies.Models.Test>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AplicacioFarmacies.Models.FarmaciaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.



            if (!context.Provincies.Any())
            {
                var arrayp = ["Girona", "Barcelona", "Lleida", "Tarragona"];
                foreach (var i in arrayp)
                {
                    var provincia = new Provincia();
                    provincia.NomProvincia = i;
                    context.Provincia.Add(provincia);
                }

                context.SaveChanges();
                using (StreamReader sr = new StreamReader("Archivos/farmacies.csv"))
                {
                    string currentLine;
                    while ((currentLine = sr.ReadLine()) != null){
                        var arrayM = currentLine.Split(";");

                        var poblacio = new Poblacio();
                        poblacio.NomPoblacio = arrayM[3];
                        poblacio.CP = arrayM[5];
                        if (arrayM[5].Substring(0, 2).Equals("08"))
                        {
                            poblacio.IdProvincia = context.Provincies.Where(x => x.NomProvincia == "Barcelona").First().Id;
                        }
                    }
                    // currentLine will be null when the StreamReader reaches the end of file
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        

                        var array = currentLine.Split(";");

                        var farmacia = new Farmacia();
                        farmacia.CodiFarmacia = array[1];
                        farmacia.NomFarmacia = array[2];
                        farmacia.TipusVia = array[3];
                        farmacia.Carrer = array[4];
                        farmacia.NumeroVia = array[5];
                        farmacia.NumeroTelefon = array[6];
                        farmacia.AreaBasicaSalut = array[7];

                        ctx.Farmacia.Add(farmacia);

                    }
                }
            }



        }
    }
}
