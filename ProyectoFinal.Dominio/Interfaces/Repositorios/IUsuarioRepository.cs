using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepository: IRepositoryBase<Usuario>
    {
        Usuario BuscarUsuario(string usuario, string contraseña, int empresaid);
    }
}
