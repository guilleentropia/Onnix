using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class PerfilService: ServiceBase<Perfil>, IPerfilService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
            :base(perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }
    }
}
