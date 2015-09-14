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


        public IEnumerable<Producto> BuscarProducto(string descripcion, int ? terceroid, int ? categoriaid, int ? marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Descripcion == descripcion && x.TerceroId == terceroid && x.CategoriaId == categoriaid
                && x.MarcaId == marcaid);
            return b;
           
        }


        public IEnumerable<Producto> BuscarProducto(int ? terceroid, int ? categoriaid, int ? marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.TerceroId == terceroid && x.CategoriaId == categoriaid
                && x.MarcaId == marcaid);
            return b;
        }

        public IEnumerable<Producto> BuscarProductosinMarca(int ? terceroid, int ? categoriaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.TerceroId == terceroid && x.CategoriaId == categoriaid);
            return b;
        }

        public IEnumerable<Producto> BuscarProductosinCategoria(int ? terceroid, int ? marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.TerceroId == terceroid && x.MarcaId == marcaid);
            return b;
        }


        public IEnumerable<Producto> BuscarProductosinProveedor(int ? categoriaid, int ? marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.CategoriaId == categoriaid && x.MarcaId == marcaid);
            return b;
        }




        public Producto BuscarProductoStock(int id)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.SingleOrDefault(x => x.Id == id);
            var c = b.Stock;
            b.Stock = c - 1;
            Context.SaveChanges();
            return b;
        }


        public IEnumerable<Producto> BuscarProducto(string talle)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Talle == talle );
            return b;
        }


        public IEnumerable<Producto> BuscarProductoporMarca(int ? marca)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.MarcaId == marca);
            return b;
        }


        public IEnumerable<Producto> BuscarProductoporCategoria(int ? categoria)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.CategoriaId == categoria);
            return b;
        }


        public IEnumerable<Producto> BuscarProductoporProveedor(int ? proveedor)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.TerceroId == proveedor);
            return b;
        }


        public IEnumerable<Producto> BuscarProductoporTallesinCategoria(string talle, int? terceroid, int? marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Talle == talle && x.TerceroId == terceroid && x.MarcaId == marcaid);
            return b;
        }


        public IEnumerable<Producto> BuscarProductoporTallesinProveedor(string talle, int? categoriaid, int? marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Talle == talle && x.CategoriaId == categoriaid && x.MarcaId == marcaid);
            return b;
        }


        public IEnumerable<Producto> BuscarProductoporTallesinMarca(string talle, int? categoriaid, int? terceroid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Talle == talle && x.CategoriaId == categoriaid && x.TerceroId == terceroid);
            return b;
        }


        public IEnumerable<Producto> BuscarProductoporTalleyCategoria(string talle, int? categoriaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Talle == talle && x.CategoriaId == categoriaid);
            return b;
        }

        public IEnumerable<Producto> BuscarProductoporTalleyProveedor(string talle, int? terceroid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Talle == talle && x.TerceroId == terceroid);
            return b;
        }

        public IEnumerable<Producto> BuscarProductoporTalleyMarca(string talle, int? marcaid)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Talle == talle && x.MarcaId == marcaid);
            return b;
        }


        public IEnumerable<Producto> BuscarProductoporCodigo(int? codigo)
        {
            var a = Context.Set<Producto>().ToList();
            var b = a.Where(x => x.Codigo == codigo);
            return b;
        }
    }
}
