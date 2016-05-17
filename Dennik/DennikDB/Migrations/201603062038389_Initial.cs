namespace DennikDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Direccion = c.String(),
                        Cliente = c.String(),
                    })
                .PrimaryKey(t => t.EventoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Eventos");
        }
    }
}
