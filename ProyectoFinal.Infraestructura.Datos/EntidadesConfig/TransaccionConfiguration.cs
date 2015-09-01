using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class TransaccionConfiguration: EntityTypeConfiguration<Transaccion>
    {
        public TransaccionConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Fecha)
                .IsRequired();

            Property(c => c.Total)
                .IsRequired();
            
            
            HasRequired(p => p.UsuarioTransaccion)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId);

            HasRequired(p => p.TerceroTransaccion)
                .WithMany()
                .HasForeignKey(p => p.TerceroId);

            HasRequired(p => p.FacturaTransaccion)
                .WithMany()
                .HasForeignKey(p => p.FacturaId);

            HasRequired(p => p.TipoTransacciones)
                .WithMany()
                .HasForeignKey(p => p.TipoTransaccionId);

            HasRequired(p => p.FormaPagoTransaccion)
                .WithMany()
                .HasForeignKey(p => p.FormaPagoId);


        }

    }
}
