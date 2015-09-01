using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Dominio.Servicios
{
    public class FormaPagoService: ServiceBase<FormaPago>, IFormaPagoService
    {
        private readonly IFormaPagoRepository _formaPagoRepository;

        public FormaPagoService(IFormaPagoRepository formaPagoRepository)
            :base(formaPagoRepository)
        {
            _formaPagoRepository = formaPagoRepository;
        }
    }
}
