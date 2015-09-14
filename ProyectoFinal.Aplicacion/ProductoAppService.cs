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


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(string descripcion, int ? terceroid, int ? categoriaid, int ? marcaid)
        {
            return _productoService.BuscarProducto(descripcion, terceroid, categoriaid, marcaid);

        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(int ? terceroid, int ? categoriaid, int ? marcaid)
        {
            return _productoService.BuscarProducto(terceroid, categoriaid, marcaid);
        }


        public Producto BuscarProductoStock(int id)
        {
            return _productoService.BuscarProductoStock(id);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(string talle)
        {
            return _productoService.BuscarProducto(talle);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductosinMarca(int ? terceroid, int ? categoriaid)
        {
            return _productoService.BuscarProductosinMarca(terceroid, categoriaid);
        }

        public System.Collections.Generic.IEnumerable<Producto> BuscarProductosinCategoria(int ? terceroid, int ? marcaid)
        {
            return _productoService.BuscarProductosinCategoria(terceroid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductosinProveedor(int ? categoriaid, int ? marcaid)
        {
            return _productoService.BuscarProductosinProveedor(categoriaid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporMarca(int ? marca)
        {
            return _productoService.BuscarProductoporMarca(marca);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporCategoria(int ? categoria)
        {
            return _productoService.BuscarProductoporCategoria(categoria);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporProveedor(int ? proveedor)
        {
            return _productoService.BuscarProductoporProveedor(proveedor);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTallesinCategoria(string talle, int? terceroid, int? marcaid)
        {
            return _productoService.BuscarProductoporTallesinCategoria(talle, terceroid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTallesinProveedor(string talle, int? categoriaid, int? marcaid)
        {
            return _productoService.BuscarProductoporTallesinProveedor(talle, categoriaid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTallesinMarca(string talle, int? categoriaid, int? terceroid)
        {
            return _productoService.BuscarProductoporTallesinMarca(talle, categoriaid, terceroid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTalleyCategoria(string talle, int? categoriaid)
        {
            return _productoService.BuscarProductoporTalleyCategoria(talle, categoriaid);
        }

        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTalleyProveedor(string talle, int? terceroid)
        {
            return _productoService.BuscarProductoporTalleyProveedor(talle, terceroid);
        }

        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTalleyMarca(string talle, int? marcaid)
        {
            return _productoService.BuscarProductoporTalleyMarca(talle, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporCodigo(int? codigo)
        {
            return _productoService.BuscarProductoporCodigo(codigo);
        }
    }
}
