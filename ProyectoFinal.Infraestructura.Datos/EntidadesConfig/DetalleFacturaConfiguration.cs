using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class DetalleFacturaConfiguration: EntityTypeConfiguration<DetalleFactura>
    {
        public DetalleFacturaConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Cantidad)
                .IsRequired();

            Property(c => c.SubTotal)
                .IsRequired();
            
            
            HasRequired(p => p.FacturaDetalleFactura)
                .WithMany()
                .HasForeignKey(p => p.FacturaId);

            HasRequired(p => p.ProductoDetalleFactura)
                .WithMany()
                .HasForeignKey(p => p.ProductoId);
            

        }
    }
}
