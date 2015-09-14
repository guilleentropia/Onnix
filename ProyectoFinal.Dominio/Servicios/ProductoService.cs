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


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(string descripcion, int ? terceroid, int ? categoriaid, int ? marcaid)
        {
            return _productoRepository.BuscarProducto(descripcion, terceroid, categoriaid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(int ? terceroid, int ? categoriaid, int ? marcaid)
        {
            return _productoRepository.BuscarProducto(terceroid, categoriaid, marcaid);
        }


        public Producto BuscarProductoStock(int id)
        {
            return _productoRepository.BuscarProductoStock(id);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProducto(string talle)
        {
            return _productoRepository.BuscarProducto(talle);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductosinMarca(int ? terceroid, int ? categoriaid)
        {
            return _productoRepository.BuscarProductosinMarca(terceroid, categoriaid);
        }

        public System.Collections.Generic.IEnumerable<Producto> BuscarProductosinCategoria(int ? terceroid, int ? marcaid)
        {
            return _productoRepository.BuscarProductosinCategoria(terceroid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductosinProveedor(int ? categoriaid, int ? marcaid)
        {
            return _productoRepository.BuscarProductosinProveedor(categoriaid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporMarca(int ? marca)
        {
            return _productoRepository.BuscarProductoporMarca(marca);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporCategoria(int ? categoria)
        {
            return _productoRepository.BuscarProductoporCategoria(categoria);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporProveedor(int ? proveedor)
        {
            return _productoRepository.BuscarProductoporProveedor(proveedor);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTallesinCategoria(string talle, int? terceroid, int? marcaid)
        {
            return _productoRepository.BuscarProductoporTallesinCategoria(talle, terceroid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTallesinProveedor(string talle, int? categoriaid, int? marcaid)
        {
            return _productoRepository.BuscarProductoporTallesinProveedor(talle, categoriaid, marcaid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTallesinMarca(string talle, int? categoriaid, int? terceroid)
        {
            return _productoRepository.BuscarProductoporTallesinMarca(talle, categoriaid, terceroid);
        }


        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTalleyCategoria(string talle, int? categoriaid)
        {
            return _productoRepository.BuscarProductoporTalleyCategoria(talle, categoriaid);
        }

        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTalleyProveedor(string talle, int? terceroid)
        {
            return _productoRepository.BuscarProductoporTalleyProveedor(talle, terceroid);
        }

        public System.Collections.Generic.IEnumerable<Producto> BuscarProductoporTalleyMarca(string talle, int? marcaid)
        {
            return _productoRepository.BuscarProductoporTalleyMarca(talle, marcaid);
        }
    }
}
