namespace AplicacioFarmacies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentaris",
                c => new
                    {
                        IdComentari = c.Int(nullable: false, identity: true),
                        NomAutorComentari = c.String(),
                        ContingutComentari = c.String(),
                        IdFarmacia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdComentari)
                .ForeignKey("dbo.Farmacias", t => t.IdFarmacia, cascadeDelete: true)
                .Index(t => t.IdFarmacia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentaris", "IdFarmacia", "dbo.Farmacias");
            DropIndex("dbo.Comentaris", new[] { "IdFarmacia" });
            DropTable("dbo.Comentaris");
        }
    }
}
