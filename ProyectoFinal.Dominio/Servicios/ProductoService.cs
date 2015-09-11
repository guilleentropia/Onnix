using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class ProductoService: ServiceBase<Producto>, IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
            :base(productoRepository)
        {
            _productoRepository = productoRepository;
        }



        public Producto BuscarProductoImagen(int id)
        {
            return _productoRepository.BuscarProductoImagen(id);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(string descripcion, int terceroid, int categoriaid, int marcaid)
        {
            return _productoRepository.BuscarProducto(descripcion, terceroid, categoriaid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(int terceroid, int categoriaid, int marcaid)
        {
            return _productoRepository.BuscarProducto(terceroid, categoriaid, marcaid);
        }


        public Producto BuscarProductoStock(int id)
        {
            return _productoRepository.BuscarProductoStock(id);
        }
    }
}
