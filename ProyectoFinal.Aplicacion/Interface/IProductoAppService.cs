using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Aplicacion.Interface
{
    public interface IProductoAppService: IAppServiceBase<Producto>
    {
       Producto BuscarProductoImagen(int id);
    }
}
