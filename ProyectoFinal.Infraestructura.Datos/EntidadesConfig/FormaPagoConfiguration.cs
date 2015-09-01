using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class FormaPagoConfiguration: EntityTypeConfiguration<FormaPago>
    {
        public FormaPagoConfiguration()
        {

            HasKey(c => c.Id);

            Property(c => c.Descripcion)
                .IsRequired()
                .HasMaxLength(100);
            
        }
    }
}
