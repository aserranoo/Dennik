namespace DennikDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventario", "Art_Descripcion", c => c.String(nullable: false));
            AddColumn("dbo.Inventario", "Art_Cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.Inventario", "Art_CodigoProducto", c => c.Int(nullable: false));
            AddColumn("dbo.Inventario", "Art_Bloqueado", c => c.Boolean(nullable: false));
            //DropColumn("dbo.Inventario", "Descripcion");
            //DropColumn("dbo.Inventario", "Cantidad");
            //DropColumn("dbo.Inventario", "Bloqueado");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Inventario", "Bloqueado", c => c.Boolean(nullable: false));
            //AddColumn("dbo.Inventario", "Cantidad", c => c.Int(nullable: false));
            //AddColumn("dbo.Inventario", "Descripcion", c => c.String());
            DropColumn("dbo.Inventario", "Art_Bloqueado");
            DropColumn("dbo.Inventario", "Art_CodigoProducto");
            DropColumn("dbo.Inventario", "Art_Cantidad");
            DropColumn("dbo.Inventario", "Art_Descripcion");
        }
    }
}
