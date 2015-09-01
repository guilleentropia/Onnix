using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.MVC5.ViewModels
{
    public class DetalleTransaccionViewModel
    {
        [Key]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Debe ingresar una cantidad valida")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }


        [Required(ErrorMessage = "El campo SubTotal es Obligatorio")]
        [Display(Name = "SubTotal de Transaccion")]
        [DataType(DataType.Currency, ErrorMessage = "Debe ingresar un monto valido")]
        public decimal SubTotal { get; set; }

        public int TransaccionId { get; set; }
        public virtual Transaccion TransaccionDetalleTransaccion { get; set; }

        public int ProductoId { get; set; }
        public virtual Producto ProductoDetalleTransaccion { get; set; }


        

    }
}