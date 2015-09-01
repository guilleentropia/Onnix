using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Infraestructura.Datos.Contexto;

namespace ProyectoFinal.Infraestructura.Datos.Repositorios
{
    public class ProductoRepository: RepositoryBase<Producto>, IProductoRepository
    {


        public Producto BuscarProductoImagen(int id)
        {


        
            return new   ProyectoFinalContexto().Set<Producto>().Find(id);
        }
    }
}
