namespace DennikDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inventario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventario",
                c => new
                    {
                        ArticuloId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Cantidad = c.Int(nullable: false),
                        Bloqueado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArticuloId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inventario");
        }
    }
}
