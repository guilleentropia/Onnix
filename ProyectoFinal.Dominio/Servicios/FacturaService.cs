using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class FacturaService: ServiceBase<Factura>, IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaService(IFacturaRepository facturaRepository)
            :base(facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public Factura UltimaFactura()
        {
            return _facturaRepository.UltimaFactura();
        }
    }
}
