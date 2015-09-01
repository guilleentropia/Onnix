using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Infraestructura.Datos.EntidadesConfig;

namespace ProyectoFinal.Infraestructura.Datos.Contexto
{
    public class ProyectoFinalContexto: DbContext
    {
        public ProyectoFinalContexto(): base("ProyectoFinal") 
        {

        }

        public DbSet<Tercero> Terceros { get; set; }
        public DbSet<TipoTercero> TipoTerceros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<FormaPago> FormasPago { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<TipoTransaccion> TipoTransacciones { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<DetalleTransaccion> DetallesTransaccion { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(x => x.Name == "Id")
                .Configure(x => x.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(150));

            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new TerceroConfiguration());
            modelBuilder.Configurations.Add(new TipoTerceroConfiguration());
            modelBuilder.Configurations.Add(new MarcaConfiguration());
            modelBuilder.Configurations.Add(new FormaPagoConfiguration());
            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new TipoTransaccionConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new EmpleadoConfiguration());
            modelBuilder.Configurations.Add(new ProductoConfiguration());
            modelBuilder.Configurations.Add(new FacturaConfiguration());
            modelBuilder.Configurations.Add(new TransaccionConfiguration());
            modelBuilder.Configurations.Add(new DetalleTransaccionConfiguration());
            modelBuilder.Configurations.Add(new DetalleFacturaConfiguration());



        }
    }
}
