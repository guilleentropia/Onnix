using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class TerceroAppService  : AppServiceBase<Tercero>, ITerceroAppService
    {
        private readonly ITerceroService _terceroService;

        public TerceroAppService(ITerceroService terceroService)
            :base (terceroService)
        {
            _terceroService = terceroService;
        }
    }
}
