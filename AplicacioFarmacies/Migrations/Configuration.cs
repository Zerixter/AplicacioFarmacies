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
            //AplicacioFarmacies.utilitats.CarregaInicial.carregaprovincies(context);
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
                using (StreamReader sr = new StreamReader("C:/Users/victo/source/repos/AplicacioFarmacies/AplicacioFarmacies/Archivos/farmacies.csv"))
                    {
                    string currentLine;
                    try
                    {
                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            var arrayM = currentLine.Split(';');
                            var CodiPostal = int.Parse(arrayM[5]);

                            if (!context.Poblacions.Where(x => x.CP == CodiPostal).Any())
                            {
                                var poblacio = new Poblacio();
                                poblacio.NomPoblacio = arrayM[3];
                                poblacio.CP = CodiPostal;
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
                        }
                    }
                    catch { 

                    }
                    try
                    {


                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            var arrayM = currentLine.Split(';');
                            var CodiPostal = int.Parse(arrayM[5]);

                            var farmacia = new Farmacia();
                            farmacia.CodiFarmacia = arrayM[1];
                            farmacia.NomFarmacia = arrayM[2];
                            farmacia.TipusVia = arrayM[6];
                            farmacia.Carrer = arrayM[4];

                            farmacia.NumeroVia = arrayM[7];
                            farmacia.NumeroTelefon = arrayM[8];
                            farmacia.AreaBasicaSalut = arrayM[9];

                            farmacia.IdPoblacio = context.Poblacions.Where(x => x.CP == CodiPostal).First().IdPoblacio;
                            context.Farmacies.Add(farmacia);

                            context.SaveChanges();
                        }
                    }catch{

                    }
                            
                    }
                }
                    // currentLine will be null when the StreamReader reaches the end of file

                    //context.SaveChanges();
                }
            }
    }


