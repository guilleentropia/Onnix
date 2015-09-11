using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Infraestructura.Datos.Contexto;
using System.Linq;
using System.Collections.Generic;

namespace ProyectoFinal.Infraestructura.Datos.Repositorios
{
    public class TransaccionRepository: RepositoryBase<Transaccion>, ITransaccionRepository
    {
        public Transaccion UltimaTransaccion()
        {
            var a = Context.Set<Transaccion>().ToList();
            var b = a.OrderByDescending(x => x.Id).FirstOrDefault();
            return b;
        }
    }
}
