using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class TipoTransaccionAppService: AppServiceBase<TipoTransaccion>, ITipoTransaccionAppService
    {
        private readonly ITipoTransaccionService _tipoTransaccionService;

        public TipoTransaccionAppService(ITipoTransaccionService tipoTransaccionService)
            :base(tipoTransaccionService)
        {
            _tipoTransaccionService = tipoTransaccionService;
        }
    }
}
