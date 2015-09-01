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
    }
}
