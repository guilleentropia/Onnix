using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class ProductoAppService: AppServiceBase<Producto>, IProductoAppService
    {
        private readonly IProductoService _productoService;

        public ProductoAppService(IProductoService productoService)
            :base(productoService)
        {
            _productoService = productoService;
        }



        public Producto BuscarProductoImagen(int id)
        {
            return _productoService.BuscarProductoImagen(id);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(string descripcion, int terceroid, int categoriaid, int marcaid)
        {
            return _productoService.BuscarProducto(descripcion, terceroid, categoriaid, marcaid);

        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(int terceroid, int categoriaid, int marcaid)
        {
            return _productoService.BuscarProducto(terceroid, categoriaid, marcaid);
        }


        public Producto BuscarProductoStock(int id)
        {
            return _productoService.BuscarProductoStock(id);
        }
    }
}
