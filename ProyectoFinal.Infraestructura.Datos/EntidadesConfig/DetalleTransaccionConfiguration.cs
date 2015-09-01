using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class DetalleTransaccionConfiguration: EntityTypeConfiguration<DetalleTransaccion>
    {
        public DetalleTransaccionConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Cantidad)
                .IsRequired();

            Property(c => c.SubTotal)
                .IsRequired();
            
            
            HasRequired(p => p.TransaccionDetalleTransaccion)
                .WithMany()
                .HasForeignKey(p => p.TransaccionId);

            HasRequired(p => p.ProductoDetalleTransaccion)
                .WithMany()
                .HasForeignKey(p => p.ProductoId);

            


        }
    }
}
