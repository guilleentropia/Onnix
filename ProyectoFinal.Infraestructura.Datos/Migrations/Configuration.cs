using System.Data.Entity.Migrations;
using ProyectoFinal.Infraestructura.Datos.Contexto;

namespace ProyectoFinal.Infraestructura.Datos.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoFinalContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProyectoFinalContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
