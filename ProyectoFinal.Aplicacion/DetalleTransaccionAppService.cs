using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class DetalleTransaccionAppService: AppServiceBase<DetalleTransaccion>, IDetalleTransaccionAppService
    {
        private readonly IDetalleTransaccionService _detalleTransaccionService;

        public DetalleTransaccionAppService(IDetalleTransaccionService detalleTransaccionService)
            :base(detalleTransaccionService)
        {
            _detalleTransaccionService = detalleTransaccionService;
        }
    }
}
