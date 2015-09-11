using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Dominio.Interfaces.Servicios
{
    public interface IUsuarioService: IServiceBase<Usuario>
    {
        Usuario BuscarUsuario(string usuario, string contraseña, int empresaid);

        Usuario BuscarIdUsuarioporNombre(string usuario);
    }
}
