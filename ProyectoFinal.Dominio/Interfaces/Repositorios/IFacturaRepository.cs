using ProyectoFinal.Dominio.Entidades;
using System.Collections.Generic;

namespace ProyectoFinal.Dominio.Interfaces.Repositorios
{
    public interface IFacturaRepository: IRepositoryBase<Factura>
    {
       Factura UltimaFactura();
    }
}
