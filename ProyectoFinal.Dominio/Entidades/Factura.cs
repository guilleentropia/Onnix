using System;

namespace ProyectoFinal.Dominio.Entidades
{
    public class Factura
    {
        // Declaracion de la Entidad Factura
        public int Id { get; set; }

        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }


        //Propiedades de Navegacion
        public int UsuarioId { get; set; }
        public virtual Usuario UsuarioFactura { get; set; }

        public int TerceroId { get; set; }
        public virtual Tercero TerceroFactura { get; set; }
    }
}
