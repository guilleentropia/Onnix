using System.Linq;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;

namespace ProyectoFinal.Infraestructura.Datos.Repositorios
{
    public class UsuarioRepository: RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario BuscarUsuario(string usuario, string contraseña, int empresaid)
        {
            var a = Context.Set<Usuario>().ToList();
            var b = a.SingleOrDefault(x => x.NombreUsuario == usuario && x.Password == contraseña && x.EmpresaId == empresaid);
            return b;
        }
    }
}
