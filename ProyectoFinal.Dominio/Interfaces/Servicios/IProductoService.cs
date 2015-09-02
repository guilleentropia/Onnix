using ProyectoFinal.Dominio.Entidades;
using System.Collections.Generic;

namespace ProyectoFinal.Dominio.Interfaces.Servicios
{
    public interface IProductoService: IServiceBase<Producto>
    {
        Producto BuscarProductoImagen(int id);

        IEnumerable<Producto> BuscarProducto(string descripcion, int terceroid, int categoriaid, int marcaid);

        IEnumerable<Producto> BuscarProducto( int terceroid, int categoriaid, int marcaid);
    }
}
