using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Aplicacion.Interface
{
    public interface IUsuarioAppService: IAppServiceBase<Usuario>
    {
        Usuario BuscarUsuario(string usuario, string contraseña, int empresaid);

        Usuario BuscarIdUsuarioporNombre(string usuario);
    }
}
