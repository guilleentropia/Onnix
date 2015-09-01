using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class DetalleTransaccionService: ServiceBase<DetalleTransaccion>, IDetalleTransaccionService
    {
        private readonly IDetalleTransaccionRepository _detalleTransaccionRepository;

        public DetalleTransaccionService(IDetalleTransaccionRepository detalleTransaccionRepository)
            :base (detalleTransaccionRepository)
        {
            _detalleTransaccionRepository = detalleTransaccionRepository;
        }
    }
}
