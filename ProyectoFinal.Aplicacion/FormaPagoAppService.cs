using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class FormaPagoAppService: AppServiceBase<FormaPago>, IFormaPagoAppService
    {
        private readonly IFormaPagoService _formaPagoService;

        public FormaPagoAppService(IFormaPagoService formaPagoService)
            :base(formaPagoService)
        {
            _formaPagoService = formaPagoService;
        }
    }
}
