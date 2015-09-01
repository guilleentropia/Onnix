namespace ProyectoFinal.Dominio.Entidades
{
    public class DetalleTransaccion
    {
        // Declaracion de la Entidad Detalle de Transaccion
        public int Id { get; set; }

        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }


        //Propiedades de Navegacion
        public int TransaccionId { get; set; }
        public virtual Transaccion TransaccionDetalleTransaccion { get; set; }

        public int ProductoId { get; set; }
        public virtual Producto ProductoDetalleTransaccion { get; set; }

        
    }
}
