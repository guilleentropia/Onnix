using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Aplicacion.Interface
{
    public interface ITransaccionAppService: IAppServiceBase<Transaccion>
    {
        Transaccion UltimaTransaccion();
    }
}
