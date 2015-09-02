using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoFinal.MVC5.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<ProyectoFinal.MVC5.ViewModels.ProductoViewModel> ProductoViewModels { get; set; }

        public System.Data.Entity.DbSet<ProyectoFinal.Dominio.Entidades.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<ProyectoFinal.Dominio.Entidades.Marca> Marcas { get; set; }

        public System.Data.Entity.DbSet<ProyectoFinal.Dominio.Entidades.Tercero> Terceroes { get; set; }
    }
}