using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Dominio.Interfaces.Repositorios
{
    public interface IProductoRepository: IRepositoryBase<Producto>
    {
        Producto BuscarProductoImagen(int id);
    }
}
