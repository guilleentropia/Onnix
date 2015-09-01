using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class PerfilConfiguration: EntityTypeConfiguration<Perfil>
    {
         public PerfilConfiguration()
        {

            HasKey(c => c.Id);

            Property(c => c.Descripcion)
                .IsRequired()
                .HasMaxLength(100);

         }
    }
}
