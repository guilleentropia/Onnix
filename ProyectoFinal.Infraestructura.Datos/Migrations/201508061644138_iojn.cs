using System.Data.Entity.Migrations;

namespace ProyectoFinal.Infraestructura.Datos.Migrations
{
    public partial class iojn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tercero", "Apellido", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Tercero", "Nombre", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Tercero", "Domicilio", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.Tercero", "Mail", c => c.String(nullable: false, maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tercero", "Mail", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Tercero", "Domicilio", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Tercero", "Nombre", c => c.String(maxLength: 150, unicode: false));
            AlterColumn("dbo.Tercero", "Apellido", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
