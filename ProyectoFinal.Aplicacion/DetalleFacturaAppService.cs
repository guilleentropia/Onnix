using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class DetalleFacturaAppService: AppServiceBase<DetalleFactura>, IDetalleFacturaAppService
    {
        private readonly IDetalleFacturaService _detalleFacturaService;

        public DetalleFacturaAppService(IDetalleFacturaService detalleFacturaService)
            :base(detalleFacturaService)
        {
            _detalleFacturaService = detalleFacturaService;
        }
    }
}
