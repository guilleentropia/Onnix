using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class EmpleadoConfiguration: EntityTypeConfiguration<Empleado>
    {

        public EmpleadoConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Apellido)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Dni)
                .IsRequired();

            Property(c => c.Domicilio)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Celular)
                .IsRequired();

            Property(c => c.Mail)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(p => p.EmpresaEmpleado)
                .WithMany()
                .HasForeignKey(p => p.EmpresaId);
        }
    }
}
