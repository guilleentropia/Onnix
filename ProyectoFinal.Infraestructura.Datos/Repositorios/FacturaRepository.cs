using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces.Repositorios;
using ProyectoFinal.Infraestructura.Datos.Contexto;
using System.Linq;
using System.Collections.Generic;

namespace ProyectoFinal.Infraestructura.Datos.Repositorios
{
    public class FacturaRepository: RepositoryBase<Factura>, IFacturaRepository
    {
        public Factura UltimaFactura()
        {
            var a = Context.Set<Factura>().ToList();
            var b = a.OrderByDescending(x => x.Id).FirstOrDefault();
            return b;
        }
    }
}
