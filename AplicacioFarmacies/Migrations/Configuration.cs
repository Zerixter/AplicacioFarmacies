namespace AplicacioFarmacies.Migrations
{
    using AplicacioFarmacies.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AplicacioFarmacies.Models.FarmaciaContext>
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
                string[] arrayp = { "Girona", "Barcelona", "Lleida", "Tarragona" };
                foreach (var i in arrayp)
                {
                    var provincia = new Provincia();
                    provincia.NomProvincia = "" + i;
                    context.Provincies.Add(provincia);
                }

                context.SaveChanges();
                using (StreamReader sr = new StreamReader("./Archivos/farmacies.csv"))
                {
                    string currentLine;
                    while ((currentLine = sr.ReadLine()) != null){
                        var arrayM = currentLine.Split(';');

                        if (!context.Poblacions.Where(x => x.CP == int.Parse(arrayM[5])).Any()){
                            var poblacio = new Poblacio();
                            poblacio.NomPoblacio = arrayM[3];
                            poblacio.CP = int.Parse(arrayM[5]);
                            if (arrayM[5].Substring(0, 2).Equals("08"))
                            {
                                poblacio.IdProvincia = context.Provincies.Where(x => x.NomProvincia == "Barcelona").First().IdProvincia;
                            }
                            if (arrayM[5].Substring(0, 2).Equals("17"))
                            {
                                poblacio.IdProvincia = context.Provincies.Where(x => x.NomProvincia == "Girona").First().IdProvincia;
                            }
                            if (arrayM[5].Substring(0, 2).Equals("25"))
                            {
                                poblacio.IdProvincia = context.Provincies.Where(x => x.NomProvincia == "Lleida").First().IdProvincia;
                            }
                            if (arrayM[5].Substring(0, 2).Equals("43"))
                            {
                                poblacio.IdProvincia = context.Provincies.Where(x => x.NomProvincia == "Tarragona").First().IdProvincia;
                            }
                            context.Poblacions.Add(poblacio);
                            context.SaveChanges();
                        }
                       

                        var farmacia = new Farmacia();
                        farmacia.CodiFarmacia = arrayM[1];
                        farmacia.NomFarmacia = arrayM[2];
                        farmacia.TipusVia = arrayM[6];
                        farmacia.Carrer = arrayM[4];
                        farmacia.NumeroVia = int.Parse(arrayM[7]);
                        farmacia.NumeroTelefon = arrayM[8];
                        farmacia.AreaBasicaSalut = arrayM[9];
                        farmacia.IdPoblacio = context.Poblacions.Where(x => x.CP == int.Parse(arrayM[5])).First().IdPoblacio;
                        context.Farmacies.Add(farmacia);

                    }
                }
                    // currentLine will be null when the StreamReader reaches the end of file

                    context.SaveChanges();
                }
            }
        }
    }

