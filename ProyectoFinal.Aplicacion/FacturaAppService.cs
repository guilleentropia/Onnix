using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class FacturaAppService: AppServiceBase<Factura>, IFacturaAppService
    {
        private readonly IFacturaService _facturaService;

        public FacturaAppService(IFacturaService facturaService)
            :base(facturaService)
        {
            _facturaService = facturaService;
        }

        public Factura UltimaFactura()
        {
            return _facturaService.UltimaFactura();
        }
    }
}
