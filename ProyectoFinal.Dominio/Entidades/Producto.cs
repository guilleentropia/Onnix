namespace ProyectoFinal.Dominio.Entidades
{
    public class Producto
    {
        // Declaracion de la Entidad Producto
        public int Id { get; set; }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public byte[] Imagen { get; set; }
             

        //Propiedades de Navegacion
        public int CategoriaId { get; set; }
        public virtual Categoria CategoriaProducto { get; set; }

        public int MarcaId { get; set; }
        public virtual Marca MarcaProducto { get; set; }

        public int TerceroId { get; set; }
        public virtual Tercero TerceroProducto { get; set; }


    }
}
