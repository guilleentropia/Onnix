using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class MarcaAppService: AppServiceBase<Marca>, IMarcaAppService
    {
        private readonly IMarcaService _marcaService;

        public MarcaAppService(IMarcaService marcaService)
            :base(marcaService)
        {
            _marcaService = marcaService;
        }
    }
}
