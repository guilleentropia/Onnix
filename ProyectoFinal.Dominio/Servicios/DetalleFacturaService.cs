using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class DetalleFacturaService: ServiceBase<DetalleFactura>, IDetalleFacturaService
    {
        private readonly IDetalleFacturaRepository _detalleFacturaRepository;

        public DetalleFacturaService(IDetalleFacturaRepository detalleFacturaRepository)
            :base(detalleFacturaRepository)
        {
            _detalleFacturaRepository = detalleFacturaRepository;
        }
    }
}
