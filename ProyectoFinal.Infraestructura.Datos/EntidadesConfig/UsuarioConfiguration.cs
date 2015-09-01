using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class UsuarioConfiguration: EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(50);

            
            HasRequired(p => p.PerfilUsuario)
                .WithMany()
                .HasForeignKey(p => p.PerfilId);

            HasRequired(p => p.EmpleadoUsuario)
                .WithMany()
                .HasForeignKey(p => p.EmpleadoId);

            HasRequired(p => p.EmpresaUsuario)
                .WithMany()
                .HasForeignKey(p => p.EmpresaId);
        }

    }
}
