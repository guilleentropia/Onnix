using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {

            HasKey(c => c.Id);

            Property(c => c.Descripcion)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
