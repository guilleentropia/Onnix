using ProyectoFinal.Aplicacion.Interface;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Servicios;

namespace ProyectoFinal.Aplicacion
{
    public class UsuarioAppService: AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            :base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Usuario BuscarUsuario(string usuario, string contraseña, int empresaid)
        {
           return _usuarioService.BuscarUsuario(usuario, contraseña, empresaid);
        }


        public Usuario BuscarIdUsuarioporNombre(string usuario)
        {
            return _usuarioService.BuscarIdUsuarioporNombre(usuario);
        }
    }
}
