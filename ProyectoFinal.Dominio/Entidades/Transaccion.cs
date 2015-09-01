using System;

namespace ProyectoFinal.Dominio.Entidades
{
    public class Transaccion
    {
        // Declaracion de la Entidad Transaccion
        public int Id { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }


        //Propiedades de Navegacion
        public int UsuarioId { get; set; }
        public virtual Usuario UsuarioTransaccion { get; set; }

        public int TerceroId { get; set; }
        public virtual Tercero TerceroTransaccion { get; set; }

        public int FacturaId { get; set; }
        public virtual Factura FacturaTransaccion { get; set; }

        public int TipoTransaccionId { get; set; }
        public virtual TipoTransaccion TipoTransacciones { get; set; }

        public int FormaPagoId { get; set; }
        public virtual FormaPago FormaPagoTransaccion { get; set; }
    }
}
