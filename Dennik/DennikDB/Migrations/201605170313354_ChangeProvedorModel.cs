namespace DennikDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProvedorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provedores", "Direccion", c => c.String());
            AddColumn("dbo.Provedores", "NumInt", c => c.String());
            AddColumn("dbo.Provedores", "NumExt", c => c.String());
            AddColumn("dbo.Provedores", "Telefono", c => c.String());
            AddColumn("dbo.Provedores", "FechaRegistro", c => c.DateTime(nullable: false));
            AddColumn("dbo.Provedores", "Correo", c => c.String());
            DropColumn("dbo.Provedores", "Direccion1");
            DropColumn("dbo.Provedores", "Direccion2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provedores", "Direccion2", c => c.String());
            AddColumn("dbo.Provedores", "Direccion1", c => c.String());
            DropColumn("dbo.Provedores", "Correo");
            DropColumn("dbo.Provedores", "FechaRegistro");
            DropColumn("dbo.Provedores", "Telefono");
            DropColumn("dbo.Provedores", "NumExt");
            DropColumn("dbo.Provedores", "NumInt");
            DropColumn("dbo.Provedores", "Direccion");
        }
    }
}
