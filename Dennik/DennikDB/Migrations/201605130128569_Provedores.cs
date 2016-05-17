namespace DennikDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Provedores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provedores",
                c => new
                    {
                        ProvedorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        RazonSocial = c.String(),
                        Direccion1 = c.String(),
                        Direccion2 = c.String(),
                        Calle = c.String(),
                        Colonia = c.String(),
                        Estado = c.String(),
                        Municipio = c.String(),
                        CP = c.String(),
                    })
                .PrimaryKey(t => t.ProvedorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Provedores");
        }
    }
}
