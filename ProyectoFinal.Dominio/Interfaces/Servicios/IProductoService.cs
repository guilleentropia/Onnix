using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Dominio.Interfaces.Servicios
{
    public interface IProductoService: IServiceBase<Producto>
    {
        Producto BuscarProductoImagen(int id);
    }
}
