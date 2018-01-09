namespace AplicacioFarmacies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Farmacias",
                c => new
                    {
                        IdFarmacia = c.Int(nullable: false, identity: true),
                        CodiFarmacia = c.String(),
                        NomFarmacia = c.String(),
                        TipusVia = c.String(),
                        Carrer = c.String(),
                        NumeroVia = c.String(),
                        NumeroTelefon = c.String(),
                        AreaBasicaSalut = c.String(),
                        IdPoblacio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFarmacia)
                .ForeignKey("dbo.Poblacios", t => t.IdPoblacio, cascadeDelete: true)
                .Index(t => t.IdPoblacio);
            
            CreateTable(
                "dbo.Poblacios",
                c => new
                    {
                        IdPoblacio = c.Int(nullable: false, identity: true),
                        NomPoblacio = c.String(),
                        CP = c.Int(nullable: false),
                        IdProvincia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPoblacio)
                .ForeignKey("dbo.Provincias", t => t.IdProvincia, cascadeDelete: true)
                .Index(t => t.IdProvincia);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        IdProvincia = c.Int(nullable: false, identity: true),
                        NomProvincia = c.String(),
                    })
                .PrimaryKey(t => t.IdProvincia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Farmacias", "IdPoblacio", "dbo.Poblacios");
            DropForeignKey("dbo.Poblacios", "IdProvincia", "dbo.Provincias");
            DropIndex("dbo.Poblacios", new[] { "IdProvincia" });
            DropIndex("dbo.Farmacias", new[] { "IdPoblacio" });
            DropTable("dbo.Provincias");
            DropTable("dbo.Poblacios");
            DropTable("dbo.Farmacias");
        }
    }
}
