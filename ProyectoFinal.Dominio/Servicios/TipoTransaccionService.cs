using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class TipoTransaccionService: ServiceBase<TipoTransaccion>,ITipoTransaccionService
    {
        private readonly ITipoTransaccionRepository _tipoTransaccionRepository;

        public TipoTransaccionService(ITipoTransaccionRepository tipoTransaccionRepository)
            :base(tipoTransaccionRepository)
        {
            _tipoTransaccionRepository = tipoTransaccionRepository;
        }
    }
}
