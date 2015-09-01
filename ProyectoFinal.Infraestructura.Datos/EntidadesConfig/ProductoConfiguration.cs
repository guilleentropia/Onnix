using System.Data.Entity.ModelConfiguration;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Infraestructura.Datos.EntidadesConfig
{
    public class ProductoConfiguration: EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguration()
        {

            HasKey(c => c.Id);

            Property(c => c.Descripcion)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.PrecioCompra)
                .IsRequired();

            Property(c => c.PrecioVenta)
                .IsRequired();

            Property(c => c.Stock)
                .IsRequired();

            Property(c => c.Imagen)
                .IsOptional();

            HasRequired(p => p.CategoriaProducto)
               .WithMany()
               .HasForeignKey(p => p.CategoriaId);

            HasRequired(p => p.MarcaProducto)
               .WithMany()
               .HasForeignKey(p => p.MarcaId);

            

        }
    }
}
