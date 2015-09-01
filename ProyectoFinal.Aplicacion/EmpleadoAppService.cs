using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class EmpleadoAppService: AppServiceBase<Empleado>, IEmpleadoAppService
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoAppService(IEmpleadoService empleadoService)
            :base(empleadoService)
        {
            _empleadoService = empleadoService;
        }
    }
}
