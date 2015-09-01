using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class TransaccionAppService: AppServiceBase<Transaccion>, ITransaccionAppService
    {
        private readonly ITransaccionService _transaccionService;

        public TransaccionAppService(ITransaccionService transaccionService)
            :base(transaccionService)
        {
            _transaccionService = transaccionService;
        }
    }
}
