using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Infraestructura.Datos.Contexto;
using System.Linq;
using System.Collections.Generic;

namespace ProyectoFinal.Infraestructura.Datos.Repositorios
{
    public class ProductoRepository: RepositoryBase<Producto>, IProductoRepository
    {


        public Producto BuscarProductoImagen(int id)
        {


        
            return new   ProyectoFinalContexto().Set<Producto>().Find(id);
        }


        public IEnumerable<Producto> BuscarProducto(string descripcion, int terceroid, int categoriaid, int marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Descripcion == descripcion && x.TerceroId == terceroid && x.CategoriaId == categoriaid
                && x.MarcaId == marcaid);
            return b;
           
        }


        public IEnumerable<Producto> BuscarProducto(int terceroid, int categoriaid, int marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.TerceroId == terceroid && x.CategoriaId == categoriaid
                && x.MarcaId == marcaid);
            return b;
        }
    }
}
