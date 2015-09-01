using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class FacturaConfiguration: EntityTypeConfiguration<Factura>
    {
        public FacturaConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.NumeroFactura)
                .IsRequired();

            Property(c => c.Fecha)
                .IsRequired();

            Property(c => c.Total)
                .IsRequired();
            
            
            HasRequired(p => p.TerceroFactura)
                .WithMany()
                .HasForeignKey(p => p.TerceroId);

            HasRequired(p => p.UsuarioFactura)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId);
        }
    }
}
