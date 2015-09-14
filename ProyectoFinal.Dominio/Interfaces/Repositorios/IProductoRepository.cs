using ProyectoFinal.Dominio.Entidades;
using System.Collections.Generic;

namespace ProyectoFinal.Dominio.Interfaces.Repositorios
{
    public interface IProductoRepository: IRepositoryBase<Producto>
    {
        Producto BuscarProductoImagen(int id);

        IEnumerable<Producto> BuscarProducto(string descripcion, int ? terceroid, int ? categoriaid, int ? marcaid);

        IEnumerable<Producto> BuscarProductosinMarca(int ? terceroid, int ? categoriaid);

        IEnumerable<Producto> BuscarProductosinCategoria(int ? terceroid, int ? marcaid);

        IEnumerable<Producto> BuscarProductosinProveedor(int ? terceroid, int ? marcaid);

        IEnumerable<Producto> BuscarProductoporMarca(int ? marca);

        IEnumerable<Producto> BuscarProductoporCodigo(int? codigo);

        IEnumerable<Producto> BuscarProductoporTallesinCategoria(string talle, int ? terceroid , int ? marcaid);

        IEnumerable<Producto> BuscarProductoporTallesinProveedor(string talle, int? categoriaid, int? marcaid);

        IEnumerable<Producto> BuscarProductoporTallesinMarca(string talle, int? categoriaid, int? terceroid);

        IEnumerable<Producto> BuscarProductoporTalleyCategoria(string talle, int? categoriaid);

        IEnumerable<Producto> BuscarProductoporTalleyProveedor(string talle, int? terceroid);

        IEnumerable<Producto> BuscarProductoporTalleyMarca(string talle, int? marcaid);

        IEnumerable<Producto> BuscarProductoporCategoria(int ? categoria);

        IEnumerable<Producto> BuscarProductoporProveedor(int ? proveedor);
        
        IEnumerable<Producto> BuscarProducto(string talle);

        IEnumerable<Producto> BuscarProducto( int ? terceroid, int ? categoriaid, int ? marcaid);

        Producto BuscarProductoStock(int id);
    }
}
