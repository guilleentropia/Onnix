using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class TerceroService : ServiceBase<Tercero>,ITerceroService
    {
        private readonly ITerceroRepository _terceroRepository;

        public TerceroService(ITerceroRepository terceroRepository)
            :base(terceroRepository)
        {
            _terceroRepository = terceroRepository;
        }
    }
}
