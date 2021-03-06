﻿using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Dominio.Interfaces.Servicios
{
    public interface ITransaccionService: IServiceBase<Transaccion>
    {
        Transaccion UltimaTransaccion();
    }
}
