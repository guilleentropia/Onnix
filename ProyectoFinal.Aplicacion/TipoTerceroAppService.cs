using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class TipoTerceroAppService : AppServiceBase<TipoTercero>, ITipoTerceroAppService
    {
        private readonly ITipoTerceroService _tipoTerceroService;

        public TipoTerceroAppService(ITipoTerceroService tipoTerceroService)
            :base(tipoTerceroService)
        {
            _tipoTerceroService = tipoTerceroService;
        }
    }
}
