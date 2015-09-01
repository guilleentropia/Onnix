namespace ProyectoFinal.Dominio.Entidades
{
    public class DetalleFactura
    {
        // Declaracion de la Entidad Detalle de Factura
        public int Id { get; set; }

        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }


        //Propiedades de Navegacion
        public int FacturaId { get; set; }
        public virtual Factura FacturaDetalleFactura { get; set; }

        public int ProductoId { get; set; }
        public virtual Producto ProductoDetalleFactura { get; set; }
    }
}
