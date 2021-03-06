﻿using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Dominio.Interfaces.Servicios
{
    public interface IFacturaService: IServiceBase<Factura>
    {
        Factura UltimaFactura();
    }
}
