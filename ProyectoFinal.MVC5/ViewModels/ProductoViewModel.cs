using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class ProductoViewModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo Codigo de Producto es obligatorio")]
        [Display(Name = "Codigo")]
        public double Codigo { get; set; }


        [Required(ErrorMessage = "El campo Producto es obligatorio")]
        [MaxLength(50, ErrorMessage = "Ha alcanzado el maximo de caracteres para el Producto")]
        [MinLength(2, ErrorMessage = "Debe ingresar un valor valido, minimo 2 caracteres..."),
        Display(Name = "Producto")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "El campo Precio de Compra es obligatorio")]
        [Display(Name = "Precio de Compra")]
        public double PrecioCompra { get; set; }

        [Required(ErrorMessage = "El campo Precio de Venta es obligatorio")]
        [Display(Name = "Precio de Venta")]
        public double PrecioVenta { get; set; }

        public int Stock { get; set; }
        [DataType(DataType.Upload)]
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