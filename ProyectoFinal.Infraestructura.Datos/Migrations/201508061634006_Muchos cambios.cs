using System.Data.Entity.Migrations;

namespace ProyectoFinal.Infraestructura.Datos.Migrations
{
    public partial class Muchoscambios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categoria");
        }
    }
}
