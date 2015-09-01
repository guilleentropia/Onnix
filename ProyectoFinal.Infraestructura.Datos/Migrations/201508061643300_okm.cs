using System.Data.Entity.Migrations;

namespace ProyectoFinal.Infraestructura.Datos.Migrations
{
    public partial class okm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categoria", "Descripcion", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categoria", "Descripcion", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
