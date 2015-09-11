using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class TransaccionService: ServiceBase<Transaccion>, ITransaccionService
    {
        private readonly ITransaccionRepository _transaccionRepository;

        public TransaccionService(ITransaccionRepository transaccionRepository)
            :base(transaccionRepository)
        {
            _transaccionRepository = transaccionRepository;
        }

        public Transaccion UltimaTransaccion()
        {
            return _transaccionRepository.UltimaTransaccion();
        }
    }
}
