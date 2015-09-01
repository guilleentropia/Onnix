using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class TipoTerceroService : ServiceBase<TipoTercero>, ITipoTerceroService
    {
        private readonly ITipoTerceroRepository _tipoTerceroRepository;

        public TipoTerceroService(ITipoTerceroRepository tipoTerceroRepository)
            : base(tipoTerceroRepository)
        {
            _tipoTerceroRepository = tipoTerceroRepository;
        }
    }
}
