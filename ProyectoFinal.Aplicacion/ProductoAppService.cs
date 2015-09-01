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
    }
}
